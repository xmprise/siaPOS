package com.siapos;

import java.net.DatagramPacket;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.DatePicker;
import android.widget.ImageButton;
import android.widget.TextView;
import android.widget.Toast;

public class SiaPOS_DateShopInfor extends Activity implements OnClickListener{
	String id;
	String startDate, endDate;
	TextView tv;
	ImageButton btn;
	DatePicker sDate;
	DatePicker eDate;
		
	public void onCreate(Bundle savedInstanceState) {

	        super.onCreate(savedInstanceState);
	        setContentView(R.layout.datesales);        
	 
	        Intent intent = getIntent();
	        id = intent.getStringExtra("id");
	        
	        tv = (TextView)findViewById(R.id.textView1);
	        tv.setText("ShopID("+id + "). SiaPOS Mobile Service.");
	
	        sDate  = (DatePicker)findViewById(R.id.datePicker1);
	        eDate = (DatePicker)findViewById(R.id.datePicker2); 
	        btn = (ImageButton)findViewById(R.id.imgSerch);
	        btn.setOnClickListener(this);      
	}

	public void onClick(View v) {
		 // TODO Auto-generated method stub
		 startDate = Integer.toString(sDate.getYear()) + "-" + Integer.toString(sDate.getMonth()+1) + "-" + Integer.toString(sDate.getDayOfMonth());
		 endDate = Integer.toString(eDate.getYear()) + "-" + Integer.toString(eDate.getMonth()+1) + "-" + Integer.toString(eDate.getDayOfMonth());
		 //Toast.makeText(this,startDate,Toast.LENGTH_SHORT).show();
		 
		 Intent intent = new Intent(this,SiaPOS_DateShopinfor_Result.class);
         intent.putExtra("id",id);
         intent.putExtra("sDate", startDate);
         intent.putExtra("eDate", endDate);
         startActivity(intent);      
	}
}
