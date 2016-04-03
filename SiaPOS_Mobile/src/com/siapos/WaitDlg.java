package com.siapos;

import android.app.ProgressDialog;
import android.content.Context;
import android.os.HandlerThread;

class WaitDlg extends HandlerThread {
    Context mContext;
    String mTitle;
    String mMsg;
    ProgressDialog mProgress;
   
    WaitDlg(Context context, String title, String msg) {
          super("waitdlg");
          mContext = context;
          mTitle = title;
          mMsg = msg;
         
          setDaemon(true);
    }
   
    protected void onLooperPrepared() {//������ run�޼ҵ尡 �ƴ϶� onLooperPrepared()�� ó���մϴ�.
          //���α׷��� ��ȭ���ڸ� ����� �κ�
          mProgress = new ProgressDialog(mContext);
          mProgress.setProgressStyle(ProgressDialog.STYLE_SPINNER);
          mProgress.setTitle(mTitle);
          mProgress.setMessage(mMsg);
          mProgress.setCancelable(false);
          mProgress.show();
    }
   
    // ������ �ܺο��� ���Ḧ ���� ȣ��ȴ�.
    static void stop(WaitDlg dlg) {
          dlg.mProgress.dismiss();
          // ��ȭ���ڰ� ������� ������ ����� ��� ��
          try { Thread.sleep(100); } catch (InterruptedException e) {;}
          // �޽��� ���� �����ؾ� ��
          dlg.getLooper().quit();//���۸� �����Ҷ��� getLooper�� �ҷ��ͼ� quit�� �����ϸ�˴ϴ�.
    }
}
