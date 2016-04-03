package com.siapos;

import java.util.ArrayList;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class SiaPOS_TopShopMenuInfor_Result extends Activity {

	private static final String SOAP_ACTION = "http://tempuri.org/getMenuTop";
	private static final String METHOD_NAME = "getMenuTop";
	private static final String NAMESPACE = "http://tempuri.org/";
	private static final String URL = "http://124.198.16.87/siapos_webservice/Service.asmx";
	
	String id, TopCount, sDate, eDate;
	TextView tv1, tv2, tv3;
	ListView mylist;
	public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.topshopmenuresult);        
        
        Intent intent = getIntent();
        id = intent.getStringExtra("id");
        TopCount = intent.getStringExtra("tv");
        sDate = intent.getStringExtra("sDate");
        eDate = intent.getStringExtra("eDate");
	
        tv1 = (TextView)findViewById(R.id.topshop_id);
        tv1.setText("ShopID("+id + "). SiaPOS Mobile Service.");
        
        tv2 = (TextView)findViewById(R.id.topshop_menucount);
        tv2.setText("Shop Top Menu Count : " + TopCount);
        
        tv3 = (TextView)findViewById(R.id.topshop_date);
        tv3.setText("Date : " + sDate + " between " + eDate);
	
        mylist = (ListView)findViewById(R.id.topshop_resultlist);
        MyDataSetting(id, TopCount ,sDate, eDate, mylist);
	}
	  private void MyDataSetting(String id, String TopCount ,String sDate, String eDate, ListView mylist) 
      {          
                Log.i("Tag", "Start");
		  		final ArrayList<String> arraylist = new ArrayList<String>();
                final ArrayAdapter<String> aa;
                aa = new ArrayAdapter<String>(this,android.R.layout.simple_list_item_1,arraylist);
                mylist.setAdapter(aa);
                                     
                try
                {
                 SoapObject request = new SoapObject(NAMESPACE,METHOD_NAME);
               	 //ByVal ID As String, ByVal State As String, ByVal SDate As String, ByVal EDate As String
               	 request.addProperty("Num",TopCount);
               	 request.addProperty("ID", id);
               	 request.addProperty("SDate",sDate);
               	 request.addProperty("EDate",eDate);
               	 SoapSerializationEnvelope Envelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
               	 Envelope.setOutputSoapObject(request);
               	 Envelope.dotNet = true;
               	 HttpTransportSE androidHttpTransport = new HttpTransportSE(URL);
               	 androidHttpTransport.call(SOAP_ACTION, Envelope);
               	 SoapObject resultString = (SoapObject)Envelope.getResponse();               
                    
               	 Log.i("Tag", resultString.toString());
               	 
               	 for(int i = 0 ; i<resultString.getPropertyCount() ; i++)
               	 {                   
               	        SoapObject data = (SoapObject)resultString.getProperty(i);
               	        arraylist.add(0,(data.getProperty(0).toString() + " - " + data.getProperty(1).toString()));                          
               	 }                   
               	 	aa.notifyDataSetChanged();
                	 }
                		catch(Exception e){}                                        
      				 }
	
}
