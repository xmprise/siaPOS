
Option Strict Off
'StickyWindows 
'   Copyright (c)2004 Corneliu I. Tusnea
'   Converted class to VB.NET (c)2010 Jason James Newland

#Region " Imported namespaces "
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
#End Region

#Region " Win32 Classes "
Public Class Win32
#Region " DLL Imports "
    <DllImport("user32.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Function GetAsyncKeyState(ByVal vKey As Integer) As Short
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Function GetDesktopWindow() As IntPtr
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Ansi, CallingConvention:=CallingConvention.Cdecl)> _
    Public Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function
#End Region

#Region " Virtual keys "
    Public Class VK
        Public Const VK_SHIFT As Integer = &H10
        Public Const VK_CONTROL As Integer = &H11
        Public Const VK_MENU As Integer = &H12
        Public Const VK_ESCAPE As Integer = &H1B

        Public Shared Function IsKeyPressed(ByVal KeyCode As Integer) As Boolean
            Return (GetAsyncKeyState(KeyCode) And &H800) = 0
        End Function
    End Class
#End Region

#Region " Window messages "
    Public Class WM
        Public Const WM_MOUSEMOVE As Integer = &H200
        Public Const WM_NCMOUSEMOVE As Integer = &HA0
        Public Const WM_NCLBUTTONDOWN As Integer = &HA1
        Public Const WM_NCLBUTTONUP As Integer = &HA2
        Public Const WM_NCLBUTTONDBLCLK As Integer = &HA3
        Public Const WM_LBUTTONDOWN As Integer = &H201
        Public Const WM_LBUTTONUP As Integer = &H202
        Public Const WM_KEYDOWN As Integer = &H100
    End Class
#End Region

#Region " Hit tests "
    Public Class HT
        Public Const HTERROR As Integer = (-2)
        Public Const HTTRANSPARENT As Integer = (-1)
        Public Const HTNOWHERE As Integer = 0
        Public Const HTCLIENT As Integer = 1
        Public Const HTCAPTION As Integer = 2
        Public Const HTSYSMENU As Integer = 3
        Public Const HTGROWBOX As Integer = 4
        Public Const HTSIZE As Integer = HTGROWBOX
        Public Const HTMENU As Integer = 5
        Public Const HTHSCROLL As Integer = 6
        Public Const HTVSCROLL As Integer = 7
        Public Const HTMINBUTTON As Integer = 8
        Public Const HTMAXBUTTON As Integer = 9
        Public Const HTLEFT As Integer = 10
        Public Const HTRIGHT As Integer = 11
        Public Const HTTOP As Integer = 12
        Public Const HTTOPLEFT As Integer = 13
        Public Const HTTOPRIGHT As Integer = 14
        Public Const HTBOTTOM As Integer = 15
        Public Const HTBOTTOMLEFT As Integer = 16
        Public Const HTBOTTOMRIGHT As Integer = 17
        Public Const HTBORDER As Integer = 18
        Public Const HTREDUCE As Integer = HTMINBUTTON
        Public Const HTZOOM As Integer = HTMAXBUTTON
        Public Const HTSIZEFIRST As Integer = HTLEFT
        Public Const HTSIZELAST As Integer = HTBOTTOMRIGHT
        Public Const HTOBJECT As Integer = 19
        Public Const HTCLOSE As Integer = 20
        Public Const HTHELP As Integer = 21
    End Class
#End Region

#Region " Bit functions "
    Public Class Bit
        Public Shared Function LoWord(ByVal DWord As Long) As Integer
            On Error Resume Next
            If DWord And &H8000& Then ' &H8000& = &H00008000
                Return DWord Or &HFFFF0000
            Else
                Return DWord And &HFFFF&
            End If
        End Function

        Public Shared Function HiWord(ByVal DWord As Long) As Integer
            On Error Resume Next
            Return (DWord And &HFFFF0000) \ &H10000
        End Function

        Public Shared Function MakeLParam(ByVal LoWord As Integer, ByVal HiWord As Integer) As Integer
            On Error Resume Next
            Return CInt((HiWord << 16) Or (LoWord And &HFFFF))
        End Function
    End Class
#End Region
End Class
#End Region

#Region " Main class "
Public Class StickyWindow
    Inherits System.Windows.Forms.NativeWindow

#Region " Declarations "
    Private Enum ResizeDir
        Top = 2
        Bottom = 4
        Left = 8
        Right = 16
    End Enum

    'Internal Message Processors
    Private Delegate Function ProcessMessage(ByRef m As Message) As Boolean
    Private MessageProcessor As ProcessMessage
    'Messages processors based on type
    Private DefaultMessageProcessor As ProcessMessage
    Private MoveMessageProcessor As ProcessMessage
    Private ResizeMessageProcessor As ProcessMessage
    'Move stuff
    Private movingForm As Boolean
    Private formOffsetPoint As Point
    'Calculated offset rect to be added !! (min distances in all directions!!)
    Private offsetPoint As Point                'Primary offset
    'Resize stuff
    Private resizingForm As Boolean
    Private resizeDirection As ResizeDir
    Private formOffsetRect As Rectangle         'Calculated rect to fix the size
    Private mousePoint As Point                 'Mouse position
    'General Stuff
    Private originalForm As Form                'The form
    Private masterForm As Form                  'The main form all other windows are associated with
    Private formRect As Rectangle               'Form bounds
    Private formOriginalRect As Rectangle       'Bounds before last operation started
    Private Shared m_stickGap As Integer = 20   'Distance to stick
    Private m_stickOnResize As Boolean
    Private m_stickOnMove As Boolean
    Private m_stickToScreen As Boolean
    Private m_stickToOther As Boolean

    Private Shared GlobalStickyWindows As New ArrayList()
#End Region

#Region " Public events "
    Public Event StickToMaster(ByVal Frm As Form)
    Public Event UnStickToMaster(ByVal Frm As Form)
    Public Event MasterFormMove(ByVal Location As Point)
#End Region

#Region " Public operations and properties "
    Public Property StickMasterForm() As Form
        Get
            On Error Resume Next
            Return masterForm
        End Get
        Set(ByVal Value As Form)
            On Error Resume Next
            masterForm = Value
        End Set
    End Property

    Public Property StickGap() As Integer
        Get
            On Error Resume Next
            Return m_stickGap
        End Get
        Set(ByVal Value As Integer)
            On Error Resume Next
            m_stickGap = Value
        End Set
    End Property

    Public Property StickOnResize() As Boolean
        Get
            On Error Resume Next
            Return m_stickOnResize
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            m_stickOnResize = Value
        End Set
    End Property

    Public Property StickOnMove() As Boolean
        Get
            On Error Resume Next
            Return m_stickOnMove
        End Get
        Set(ByVal Value As Boolean)
            m_stickOnMove = Value
        End Set
    End Property

    Public Property StickToScreen() As Boolean
        Get
            On Error Resume Next
            Return m_stickToScreen
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            m_stickToScreen = Value
        End Set
    End Property

    Public Property StickToOther() As Boolean
        Get
            On Error Resume Next
            Return m_stickToOther
        End Get
        Set(ByVal Value As Boolean)
            On Error Resume Next
            m_stickToOther = Value
        End Set
    End Property

    Public Shared Sub RegisterExternalReferenceForm(ByVal frmExternal As Form)
        On Error Resume Next
        GlobalStickyWindows.Add(frmExternal)
    End Sub

    Public Shared Sub UnregisterExternalReferenceForm(ByVal frmExternal As Form)
        On Error Resume Next
        GlobalStickyWindows.Remove(frmExternal)
    End Sub
#End Region

#Region " StickyWindow Constructor "
    Public Sub New(ByVal Frm As Form)
        On Error Resume Next
        resizingForm = False
        movingForm = False
        '
        originalForm = Frm
        '
        formRect = Rectangle.Empty
        formOffsetRect = Rectangle.Empty
        '
        formOffsetPoint = Point.Empty
        offsetPoint = Point.Empty
        mousePoint = Point.Empty
        '
        m_stickOnMove = True
        m_stickOnResize = True
        m_stickToScreen = True
        m_stickToOther = True
        '
        DefaultMessageProcessor = New ProcessMessage(AddressOf DefaultMsgProcessor)
        MoveMessageProcessor = New ProcessMessage(AddressOf MoveMsgProcessor)
        ResizeMessageProcessor = New ProcessMessage(AddressOf ResizeMsgProcessor)
        MessageProcessor = DefaultMessageProcessor
        '
        AssignHandle(originalForm.Handle)
    End Sub
#End Region

#Region " OnHandleChange "
    <System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub OnHandleChange()
        On Error Resume Next
        If CInt(Me.Handle) <> 0 Then
            GlobalStickyWindows.Add(Me.originalForm)
        Else
            GlobalStickyWindows.Remove(Me.originalForm)
        End If
    End Sub
#End Region

#Region " WndProc "
    <System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
    Protected Overrides Sub WndProc(ByRef m As Message)
        On Error Resume Next
        If Not MessageProcessor(m) Then
            'Return processing back to default processor
            MyBase.WndProc(m)
        End If
    End Sub
#End Region

#Region " DefaultMsgProcessor "
    Private Function DefaultMsgProcessor(ByRef m As Message) As Boolean
        On Error Resume Next
        '
        Select Case m.Msg
            Case Win32.WM.WM_NCLBUTTONDOWN
                If True Then
                    originalForm.Activate()
                    mousePoint.X = CShort(Win32.Bit.LoWord(CInt(m.LParam)))
                    mousePoint.Y = CShort(Win32.Bit.HiWord(CInt(m.LParam)))
                    If OnNCLButtonDown(CInt(m.WParam), mousePoint) Then
                        m.Result = CType(If((resizingForm OrElse movingForm), 1, 0), IntPtr)
                        Return True
                    End If
                    Exit Select
                End If
        End Select
        '
        Return False
    End Function
#End Region

#Region " OnNCLButtonDown "
    Private Function OnNCLButtonDown(ByVal iHitTest As Integer, ByVal point As Point) As Boolean
        On Error Resume Next
        Dim rParent As Rectangle = originalForm.Bounds
        offsetPoint = point
        '
        Select Case iHitTest
            Case Win32.HT.HTCAPTION
                If True Then
                    'Request for move
                    If m_stickOnMove Then
                        offsetPoint.Offset(-rParent.Left, -rParent.Top)
                        StartMove()
                        Return True
                    Else
                        Return False
                    End If
                    'Leave default processing
                End If
                'Requests for resize
            Case Win32.HT.HTTOPLEFT
                Return StartResize(ResizeDir.Top Or ResizeDir.Left)
            Case Win32.HT.HTTOP
                Return StartResize(ResizeDir.Top)
            Case Win32.HT.HTTOPRIGHT
                Return StartResize(ResizeDir.Top Or ResizeDir.Right)
            Case Win32.HT.HTRIGHT
                Return StartResize(ResizeDir.Right)
            Case Win32.HT.HTBOTTOMRIGHT
                Return StartResize(ResizeDir.Bottom Or ResizeDir.Right)
            Case Win32.HT.HTBOTTOM
                Return StartResize(ResizeDir.Bottom)
            Case Win32.HT.HTBOTTOMLEFT
                Return StartResize(ResizeDir.Bottom Or ResizeDir.Left)
            Case Win32.HT.HTLEFT
                Return StartResize(ResizeDir.Left)
        End Select
        '
        Return False
    End Function
#End Region

#Region " Resize Operations "
    Private Function StartResize(ByVal resDir As ResizeDir) As Boolean
        On Error Resume Next
        If m_stickOnResize Then
            resizeDirection = resDir
            formRect = originalForm.Bounds
            formOriginalRect = originalForm.Bounds
            'Save the old bounds
            If Not originalForm.Capture Then
                'Start capturing messages
                originalForm.Capture = True
            End If
            '
            MessageProcessor = ResizeMessageProcessor
            'Catch the message
            Return True
        Else
            Return False
        End If
        'Leave default processing!
    End Function

    Private Function ResizeMsgProcessor(ByRef m As Message) As Boolean
        On Error Resume Next
        If Not originalForm.Capture Then
            Cancel()
            Return False
        End If
        '
        Select Case m.Msg
            Case Win32.WM.WM_LBUTTONUP
                If True Then
                    'Ok, resize finished !!!
                    EndResize()
                    Exit Select
                End If
            Case Win32.WM.WM_MOUSEMOVE
                If True Then
                    mousePoint.X = CShort(Win32.Bit.LoWord(CInt(m.LParam)))
                    mousePoint.Y = CShort(Win32.Bit.HiWord(CInt(m.LParam)))
                    Resize(mousePoint)
                    Exit Select
                End If
            Case Win32.WM.WM_KEYDOWN
                If True Then
                    If CInt(m.WParam) = Win32.VK.VK_ESCAPE Then
                        originalForm.Bounds = formOriginalRect
                        'Set back old size
                        Cancel()
                    End If
                    Exit Select
                End If
        End Select
        '
        Return False
    End Function

    Private Sub EndResize()
        On Error Resume Next
        Cancel()
    End Sub
#End Region

#Region " Resize Computing "
    Private Sub Resize(ByVal p As Point)
        On Error Resume Next
        p = originalForm.PointToScreen(p)
        Dim activeScr As Screen = Screen.FromPoint(p)
        formRect = originalForm.Bounds
        '
        Dim iRight As Integer = formRect.Right
        Dim iBottom As Integer = formRect.Bottom
        'No normalize required
        '   first strech the window to the new position
        If (resizeDirection And ResizeDir.Left) = ResizeDir.Left Then
            formRect.Width = formRect.X - p.X + formRect.Width
            formRect.X = iRight - formRect.Width
        End If
        If (resizeDirection And ResizeDir.Right) = ResizeDir.Right Then
            formRect.Width = p.X - formRect.Left
        End If
        '
        If (resizeDirection And ResizeDir.Top) = ResizeDir.Top Then
            formRect.Height = formRect.Height - p.Y + formRect.Top
            formRect.Y = iBottom - formRect.Height
        End If
        If (resizeDirection And ResizeDir.Bottom) = ResizeDir.Bottom Then
            formRect.Height = p.Y - formRect.Top
        End If
        'This is the real new position
        '   now, try to snap it to different objects (first to screen)
        '   CARE !!! We use "Width" and "Height" as Bottom & Right!! (C++ style)
        formOffsetRect.X = m_stickGap + 1
        formOffsetRect.Y = m_stickGap + 1
        formOffsetRect.Height = 0
        formOffsetRect.Width = 0
        If m_stickToScreen Then
            Resize_Stick(activeScr.WorkingArea, False)
        End If
        If m_stickToOther Then
            'Now try to stick to other forms
            For Each sw As Form In GlobalStickyWindows
                If sw IsNot Me.originalForm Then
                    Resize_Stick(sw.Bounds, True)
                End If
            Next
        End If
        'Fix (clear) the values that were not updated to stick
        If formOffsetRect.X = m_stickGap + 1 Then
            formOffsetRect.X = 0
        End If
        If formOffsetRect.Width = m_stickGap + 1 Then
            formOffsetRect.Width = 0
        End If
        If formOffsetRect.Y = m_stickGap + 1 Then
            formOffsetRect.Y = 0
        End If
        If formOffsetRect.Height = m_stickGap + 1 Then
            formOffsetRect.Height = 0
        End If
        'Compute the new form size
        If (resizeDirection And ResizeDir.Left) = ResizeDir.Left Then
            'Left resize requires special handling of X & Width acording
            '   to MinSize and MinWindowTrackSize
            Dim iNewWidth As Integer = formRect.Width + formOffsetRect.Width + formOffsetRect.X
            If originalForm.MaximumSize.Width <> 0 Then
                iNewWidth = Math.Min(iNewWidth, originalForm.MaximumSize.Width)
            End If
            '
            iNewWidth = Math.Min(iNewWidth, SystemInformation.MaxWindowTrackSize.Width)
            iNewWidth = Math.Max(iNewWidth, originalForm.MinimumSize.Width)
            iNewWidth = Math.Max(iNewWidth, SystemInformation.MinWindowTrackSize.Width)
            '
            formRect.X = iRight - iNewWidth
            formRect.Width = iNewWidth
        Else
            'Other resizes
            formRect.Width += formOffsetRect.Width + formOffsetRect.X
        End If
        '
        If (resizeDirection And ResizeDir.Top) = ResizeDir.Top Then
            Dim iNewHeight As Integer = formRect.Height + formOffsetRect.Height + formOffsetRect.Y
            If originalForm.MaximumSize.Height <> 0 Then
                iNewHeight = Math.Min(iNewHeight, originalForm.MaximumSize.Height)
            End If
            '
            iNewHeight = Math.Min(iNewHeight, SystemInformation.MaxWindowTrackSize.Height)
            iNewHeight = Math.Max(iNewHeight, originalForm.MinimumSize.Height)
            iNewHeight = Math.Max(iNewHeight, SystemInformation.MinWindowTrackSize.Height)
            '
            formRect.Y = iBottom - iNewHeight
            formRect.Height = iNewHeight
        Else
            'All other resizing are fine 
            formRect.Height += formOffsetRect.Height + formOffsetRect.Y
        End If
        'Done !!
        originalForm.Bounds = formRect
    End Sub

    Private Sub Resize_Stick(ByVal toRect As Rectangle, ByVal bInsideStick As Boolean)
        On Error Resume Next
        If formRect.Right >= (toRect.Left - m_stickGap) AndAlso formRect.Left <= (toRect.Right + m_stickGap) Then
            If (resizeDirection And ResizeDir.Top) = ResizeDir.Top Then
                If Math.Abs(formRect.Top - toRect.Bottom) <= Math.Abs(formOffsetRect.Top) AndAlso bInsideStick Then
                    formOffsetRect.Y = formRect.Top - toRect.Bottom
                    'Snap top to bottom
                ElseIf Math.Abs(formRect.Top - toRect.Top) <= Math.Abs(formOffsetRect.Top) Then
                    formOffsetRect.Y = formRect.Top - toRect.Top
                    'Snap top to top
                End If
            End If

            If (resizeDirection And ResizeDir.Bottom) = ResizeDir.Bottom Then
                If Math.Abs(formRect.Bottom - toRect.Top) <= Math.Abs(formOffsetRect.Bottom) AndAlso bInsideStick Then
                    formOffsetRect.Height = toRect.Top - formRect.Bottom
                    'Snap Bottom to top
                ElseIf Math.Abs(formRect.Bottom - toRect.Bottom) <= Math.Abs(formOffsetRect.Bottom) Then
                    formOffsetRect.Height = toRect.Bottom - formRect.Bottom
                    'Snap bottom to bottom
                End If
            End If
        End If
        '
        If formRect.Bottom >= (toRect.Top - m_stickGap) AndAlso formRect.Top <= (toRect.Bottom + m_stickGap) Then
            If (resizeDirection And ResizeDir.Right) = ResizeDir.Right Then
                If Math.Abs(formRect.Right - toRect.Left) <= Math.Abs(formOffsetRect.Right) AndAlso bInsideStick Then
                    formOffsetRect.Width = toRect.Left - formRect.Right
                    'Stick right to left
                ElseIf Math.Abs(formRect.Right - toRect.Right) <= Math.Abs(formOffsetRect.Right) Then
                    formOffsetRect.Width = toRect.Right - formRect.Right
                    'Stick right to right
                End If
            End If
            '
            If (resizeDirection And ResizeDir.Left) = ResizeDir.Left Then
                If Math.Abs(formRect.Left - toRect.Right) <= Math.Abs(formOffsetRect.Left) AndAlso bInsideStick Then
                    formOffsetRect.X = formRect.Left - toRect.Right
                    'Stick left to right
                ElseIf Math.Abs(formRect.Left - toRect.Left) <= Math.Abs(formOffsetRect.Left) Then
                    formOffsetRect.X = formRect.Left - toRect.Left
                    'Stick left to left
                End If
            End If
        End If
    End Sub
#End Region

#Region " Move Operations "
    Private Sub StartMove()
        On Error Resume Next
        formRect = originalForm.Bounds
        formOriginalRect = originalForm.Bounds
        'Save original position
        If Not originalForm.Capture Then
            'Start capturing messages
            originalForm.Capture = True
        End If
        '
        MessageProcessor = MoveMessageProcessor
    End Sub

    Private Function MoveMsgProcessor(ByRef m As Message) As Boolean
        On Error Resume Next
        'Internal message loop
        If Not originalForm.Capture Then
            Cancel()
            Return False
        End If

        Select Case m.Msg
            Case Win32.WM.WM_LBUTTONUP
                If True Then
                    'Ok, move finished !!!
                    EndMove()
                    Exit Select
                End If
            Case Win32.WM.WM_MOUSEMOVE
                If True Then
                    mousePoint.X = CShort(Win32.Bit.LoWord(CInt(m.LParam)))
                    mousePoint.Y = CShort(Win32.Bit.HiWord(CInt(m.LParam)))
                    Move(mousePoint)
                    Exit Select
                End If
            Case Win32.WM.WM_KEYDOWN
                If True Then
                    If CInt(m.WParam) = Win32.VK.VK_ESCAPE Then
                        originalForm.Bounds = formOriginalRect
                        'Set back old size
                        Cancel()
                    End If
                    Exit Select
                End If
        End Select
        '
        Return False
    End Function

    Private Sub EndMove()
        On Error Resume Next
        Cancel()
    End Sub
#End Region

#Region " Private methods "
    Private Sub Move(ByVal p As Point)
        On Error Resume Next
        p = originalForm.PointToScreen(p)
        Dim activeScr As Screen = Screen.FromPoint(p)
        'Get the screen from the point !!
        If Not activeScr.WorkingArea.Contains(p) Then
            p.X = NormalizeInside(p.X, activeScr.WorkingArea.Left, activeScr.WorkingArea.Right)
            p.Y = NormalizeInside(p.Y, activeScr.WorkingArea.Top, activeScr.WorkingArea.Bottom)
        End If
        p.Offset(-offsetPoint.X, -offsetPoint.Y)
        'p is the exact location of the frame - so we can play with it
        '   to detect the new position acording to different bounds
        formRect.Location = p
        'This is the new positon of the form
        formOffsetPoint.X = m_stickGap + 1
        '(More than) maximum gaps
        formOffsetPoint.Y = m_stickGap + 1
        '
        If m_stickToScreen Then
            Move_Stick(activeScr.WorkingArea, False)
        End If
        'Now try to snap to other windows
        If m_stickToOther Then
            For Each sw As Form In GlobalStickyWindows
                If sw IsNot Me.originalForm Then
                    If Move_Stick(sw.Bounds, True) Then
                        If Not masterForm Is Nothing Then
                            If sw Is masterForm Then
                                'Another form was stuck to the main form
                                RaiseEvent StickToMaster(originalForm)
                            End If
                            If originalForm Is masterForm Then
                                'Main form was stuck to another form
                                RaiseEvent StickToMaster(sw)
                            End If
                        End If
                    Else
                        If Not masterForm Is Nothing Then
                            If sw Is masterForm Then
                                'Another form was unstuck from the main form
                                RaiseEvent UnStickToMaster(originalForm)
                            End If
                            If originalForm Is masterForm Then
                                'Main form was unstuck from another form
                                RaiseEvent UnStickToMaster(sw)
                            End If
                        End If
                    End If
                Else
                    If sw Is masterForm Then
                        'Main form is currently moving
                        RaiseEvent MasterFormMove(p)
                    End If
                End If
            Next
        End If
        '
        If formOffsetPoint.X = m_stickGap + 1 Then
            formOffsetPoint.X = 0
        End If
        If formOffsetPoint.Y = m_stickGap + 1 Then
            formOffsetPoint.Y = 0
        End If
        '
        formRect.Offset(formOffsetPoint)
        originalForm.Bounds = formRect
    End Sub

    Private Function Move_Stick(ByVal toRect As Rectangle, ByVal bInsideStick As Boolean) As Boolean
        On Error Resume Next
        Dim bStick As Boolean
        'Compare distance from toRect to formRect
        '   and then with the found distances, compare the most closed position
        If formRect.Bottom >= (toRect.Top - m_stickGap) AndAlso formRect.Top <= (toRect.Bottom + m_stickGap) Then
            If bInsideStick Then
                If (Math.Abs(formRect.Left - toRect.Right) <= Math.Abs(formOffsetPoint.X)) Then
                    'Left 2 right
                    formOffsetPoint.X = toRect.Right - formRect.Left
                    bStick = True
                End If
                If (Math.Abs(formRect.Left + formRect.Width - toRect.Left) <= Math.Abs(formOffsetPoint.X)) Then
                    'Right 2 left
                    formOffsetPoint.X = toRect.Left - formRect.Width - formRect.Left
                    bStick = True
                End If
            End If
            '
            If Math.Abs(formRect.Left - toRect.Left) <= Math.Abs(formOffsetPoint.X) Then
                'Snap left 2 left
                formOffsetPoint.X = toRect.Left - formRect.Left
                bStick = True
            End If
            If Math.Abs(formRect.Left + formRect.Width - toRect.Left - toRect.Width) <= Math.Abs(formOffsetPoint.X) Then
                'Snap right 2 right
                formOffsetPoint.X = toRect.Left + toRect.Width - formRect.Width - formRect.Left
                bStick = True
            End If
        End If
        '
        If formRect.Right >= (toRect.Left - m_stickGap) AndAlso formRect.Left <= (toRect.Right + m_stickGap) Then
            If bInsideStick Then
                If Math.Abs(formRect.Top - toRect.Bottom) <= Math.Abs(formOffsetPoint.Y) AndAlso bInsideStick Then
                    'Stick Top to Bottom
                    formOffsetPoint.Y = toRect.Bottom - formRect.Top
                    bStick = True
                End If
                If Math.Abs(formRect.Top + formRect.Height - toRect.Top) <= Math.Abs(formOffsetPoint.Y) AndAlso bInsideStick Then
                    'Snap Bottom to Top
                    formOffsetPoint.Y = toRect.Top - formRect.Height - formRect.Top
                    bStick = True
                End If
            End If
            'Try to snap top 2 top also
            If Math.Abs(formRect.Top - toRect.Top) <= Math.Abs(formOffsetPoint.Y) Then
                'Top 2 top
                formOffsetPoint.Y = toRect.Top - formRect.Top
                bStick = True
            End If
            If Math.Abs(formRect.Top + formRect.Height - toRect.Top - toRect.Height) <= Math.Abs(formOffsetPoint.Y) Then
                'Bottom 2 bottom
                formOffsetPoint.Y = toRect.Top + toRect.Height - formRect.Height - formRect.Top
                bStick = True
            End If
        End If
        '
        Return bStick
    End Function

    Private Function NormalizeInside(ByVal iP1 As Integer, ByVal iM1 As Integer, ByVal iM2 As Integer) As Integer
        On Error Resume Next
        If iP1 <= iM1 Then
            Return iM1
        ElseIf iP1 >= iM2 Then
            Return iM2
        End If
        Return iP1
    End Function

    Private Sub Cancel()
        On Error Resume Next
        originalForm.Capture = False
        movingForm = False
        resizingForm = False
        MessageProcessor = DefaultMessageProcessor
    End Sub
#End Region
End Class
#End Region