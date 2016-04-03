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
   
    protected void onLooperPrepared() {//기존의 run메소드가 아니라 onLooperPrepared()로 처리합니다.
          //프로그래스 대화상자를 만드는 부분
          mProgress = new ProgressDialog(mContext);
          mProgress.setProgressStyle(ProgressDialog.STYLE_SPINNER);
          mProgress.setTitle(mTitle);
          mProgress.setMessage(mMsg);
          mProgress.setCancelable(false);
          mProgress.show();
    }
   
    // 스레드 외부에서 종료를 위해 호출된다.
    static void stop(WaitDlg dlg) {
          dlg.mProgress.dismiss();
          // 대화상자가 사라지기 전까지 대기해 줘야 함
          try { Thread.sleep(100); } catch (InterruptedException e) {;}
          // 메시지 루프 종료해야 함
          dlg.getLooper().quit();//루퍼를 종료할때는 getLooper로 불러와서 quit로 종료하면됩니다.
    }
}
