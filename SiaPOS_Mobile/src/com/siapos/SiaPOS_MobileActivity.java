package com.siapos;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.app.ProgressDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.Toast;

public class SiaPOS_MobileActivity extends Activity implements View.OnClickListener{
	  private static final String SOAP_ACTION = "http://tempuri.org/Login";
	     private static final String METHOD_NAME = "Login";
	     private static final String NAMESPACE = "http://tempuri.org/";
	     private static final String URL = "http://124.198.16.87/siapos_webservice/Service.asmx";
	     
	     final Activity activity = this;
	     EditText et_id,et_pw;
	     ImageButton btn;
	     ProgressDialog mProgress;
	     
	    @Override
	    public void onCreate(Bundle savedInstanceState) {

	        super.onCreate(savedInstanceState);
	        setContentView(R.layout.login);        

	        et_id = (EditText)findViewById(R.id.shopID);
	        et_pw = (EditText)findViewById(R.id.shopName);        
	        btn = (ImageButton)findViewById(R.id.imageButton1);
	        btn.setOnClickListener(this);        

	    }        

	    public void onClick(View v){     
	          
	          WaitDlg dlg = new WaitDlg(SiaPOS_MobileActivity.this, "Enter the SiaPOS Service...", "Please wait a second");
	          dlg.start();

	          String result = Login();
	          
	      	  
	          if(result.equals("succes")){
	              Intent intent = new Intent(this,SiaPOS_MainMenu.class);
	              intent.putExtra("id",et_id.getText().toString());
	              startActivity(intent);             
	           }
	          else{
	               Toast.makeText(SiaPOS_MobileActivity.this, "Fail Login, Check your ID and ShopName.",1000).show();
	           }
	          WaitDlg.stop(dlg);
	    }   

	    public String Login(){

	          try{
	              SoapObject request = new SoapObject(NAMESPACE, METHOD_NAME);
	              request.addProperty("id", et_id.getText().toString());
	              request.addProperty("password", et_pw.getText().toString());
	              SoapSerializationEnvelope envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
	              envelope.setOutputSoapObject(request);
	              envelope.dotNet = true;           
	              HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
	              androidHttpTransport.call(SOAP_ACTION, envelope);
	              SoapPrimitive resultString = (SoapPrimitive) envelope.getResponse();

	              return resultString.toString();

	          	  }catch (Exception e) {}     

	          	  return null;
	    }       
}