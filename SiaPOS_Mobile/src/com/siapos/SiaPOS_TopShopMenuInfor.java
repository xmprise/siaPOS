package com.siapos;

import android.app.Activity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.ImageButton;
import android.widget.TextView;

public class SiaPOS_TopShopMenuInfor extends Activity implements OnClickListener{
	String id;
	String TopCount,startDate, endDate;
	TextView tv;
	EditText et;
	ImageButton btn;
	DatePicker sDate;
	DatePicker eDate;
		
	public void onCreate(Bundle savedInstanceState) {

	        super.onCreate(savedInstanceState);
	        setContentView(R.layout.topmenu);        
	 
	        Intent intent = getIntent();
	        id = intent.getStringExtra("id");
	        tv = (TextView)findViewById(R.id.topmenu_userid);
	        tv.setText("ShopID("+id + "). SiaPOS Mobile Service.");
	
	        et = (EditText)findViewById(R.id.topmenu_count);
	        sDate  = (DatePicker)findViewById(R.id.topmenu_sDate);
	        eDate = (DatePicker)findViewById(R.id.topmenu_eDate); 
	        btn = (ImageButton)findViewById(R.id.topmenu_btn);
	        btn.setOnClickListener(this);      
	}

	public void onClick(View v) {
		 // TODO Auto-generated method stub
		 
		 TopCount = et.getText().toString();
		 startDate = Integer.toString(sDate.getYear()) + "-" + Integer.toString(sDate.getMonth()+1) + "-" + Integer.toString(sDate.getDayOfMonth());
		 endDate = Integer.toString(eDate.getYear()) + "-" + Integer.toString(eDate.getMonth()+1) + "-" + Integer.toString(eDate.getDayOfMonth());
		 //Toast.makeText(this,startDate,Toast.LENGTH_SHORT).show();
		 
		 Intent intent = new Intent(this,SiaPOS_TopShopMenuInfor_Result.class);
         intent.putExtra("id",id);
         intent.putExtra("tv", TopCount);
         intent.putExtra("sDate", startDate);
         intent.putExtra("eDate", endDate);
         startActivity(intent);      
	}
}
