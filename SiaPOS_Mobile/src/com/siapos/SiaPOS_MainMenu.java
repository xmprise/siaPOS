package com.siapos;

import java.util.ArrayList;

import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageButton;
import android.widget.ListView;
import android.widget.TextView;

public class SiaPOS_MainMenu extends Activity {

	String id;
	TextView tv;
	
	class MyItem{
		String Name;
		
		MyItem(String aName){
			Name = aName;
		}
	}
	
	public void onCreate(Bundle savedInstanceState) {

        super.onCreate(savedInstanceState);
        setContentView(R.layout.mainmenu);      
        Intent intent = getIntent();
        id = intent.getStringExtra("id");
        
        tv = (TextView)findViewById(R.id.userID);
        tv.setText("ShopID("+id + ") Welcome SiaPOS Mobile.");
    
        ArrayList<MyItem> arItem = new ArrayList<MyItem>();
        
        MyItem mi;
        mi = new MyItem("Current Shop Sales");
        arItem.add(mi);
        
        mi = new MyItem("Date Shop Sales");
        arItem.add(mi);
        
        mi = new MyItem("Total Shop Sales");
        arItem.add(mi);
        
        mi = new MyItem("Top Shop Menu");
        arItem.add(mi);
        
        // Context ,   LAYOUT ID,     Object        
        MyListAdapter MyAdapter = new MyListAdapter(this, R.layout.adapter, arItem);
        
        ListView MyList =(ListView)findViewById(R.id.listView1);
        MyList.setAdapter(MyAdapter);

	}

	class MyListAdapter extends BaseAdapter{
		Context maincon;
		LayoutInflater Inflater;
		ArrayList<MyItem> arSrc;
		int layout;
		                      // Context ,   LAYOUT ID,     Object
		public MyListAdapter(Context context, int alayout, ArrayList<MyItem> aarSrc){
			maincon = context;
			Inflater = (LayoutInflater)context.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
			arSrc = aarSrc;
			layout = alayout;
		}

		public int getCount() { 
			return arSrc.size();
		}

		public Object getItem(int position) { 
			return arSrc.get(position).Name;
		}

		public long getItemId(int position) {
			return position;
		}

		public View getView(int position, View convertView, ViewGroup parent) {
			
			final int pos = position;
			
			if(convertView == null){
				convertView = Inflater.inflate(layout, parent, false);
			}
			
			// 텍스트뷰
			TextView txt = (TextView)convertView.findViewById(R.id.txt);
			txt.setText(arSrc.get(position).Name);
			
			// 버튼
			ImageButton btn = (ImageButton)convertView.findViewById(R.id.imgbtn1);
			btn.setOnClickListener(new ImageButton.OnClickListener()
			{

				public void onClick(View v)
				{
					String str;
					switch(pos){
					case 0: //Current Shop Sales
						str = arSrc.get(0).Name + "가 선택되었다. - ";
						Log.i("MainMenu", str);
						//Toast.makeText(maincon, str, Toast.LENGTH_SHORT).show();
						Intent Current = new Intent(maincon, SiaPOS_CurrentShopInfor.class);
						Current.putExtra("id", id);
						startActivity(Current);
						break;
					case 1: //Date Shop Sales
						str = arSrc.get(1).Name + "가 선택되었다. - ";
						Log.i("MainMenu", str);
						//Toast.makeText(maincon, str, Toast.LENGTH_SHORT).show();
						Intent intent = new Intent(maincon,SiaPOS_DateShopInfor.class);
			            intent.putExtra("id",id);
			            startActivity(intent);        
						break;
					case 2: //Total Shop Sales
						str = arSrc.get(2).Name + "가 선택되었다. - ";
						Log.i("MainMenu", str);
						//Toast.makeText(maincon, str, Toast.LENGTH_SHORT).show();
						Intent Total = new Intent(maincon, SiaPOS_TotalShopSales.class);
						Total.putExtra("id", id);
						startActivity(Total);
						break;
					case 3: //Top Menu
						str = arSrc.get(3).Name + "가 선택되었다. -";
						Log.i("MainMenu", str);
						Intent TopShop = new Intent(maincon, SiaPOS_TopShopMenuInfor.class);
						TopShop.putExtra("id", id);
						startActivity(TopShop);
						break;
					}
						
				}
			
			});
			
			return convertView;
		}
	}
}
