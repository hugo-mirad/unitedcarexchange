package com.uce.sellacar;

import java.util.ArrayList;
import java.util.HashMap;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import android.app.Activity;
import android.app.AlertDialog;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.DisplayMetrics;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.unitedcars.home.JSONParser;
import com.unitedcars.home.MainHomeScreen;
import com.unitedcars.home.R;

public class Seller_Package_Standard extends Activity {
	public static final int TABLET_MIN_DP_WEIGHT = 450;
	public boolean isOnline() {

		ConnectivityManager conMgr = (ConnectivityManager) getApplicationContext()
				.getSystemService(Context.CONNECTIVITY_SERVICE);
		NetworkInfo netInfo = conMgr.getActiveNetworkInfo();
		if (netInfo == null || !netInfo.isConnected() || !netInfo.isAvailable()) {
			return false;
		}
		return true;
	};
	static String Carid;

	TextView tv_packagename, tv_dateofpurchase, tv_validtill, tv_postedcars,
			tv_maxcars;
	String packaname, dateofpurchase, validtill, postedcars, maxcars;
	Button btn_addacar, btn_sellerpackage_done;
	String packageid, seller_carid, url;
	String Uid = "ds3lkDFD1F5fFGnf2daFs45REsd6re54yb0sc654";
	String Uno = MainHomeScreen.CustomerID;
	ListView basic_lv;
	ProgressDialog pDialog;

	public static final String TAG_MAKE = "_make";
	public static final String TAG_YEAR = "_yearOfMake";
	public static final String TAG_model = "_model";
	public static final String TAG_Mileage = "_mileage";
	public static final String TAG_PRICE = "_price";
	public static final String TAG_picloc = "_PICLOC0";
	public static final String TAG_pic = "_PIC0";
	public static final String TAG_IMAGE = null;
	public static final String TAG_CARID = "_carid";
	ImageView imageview;
	Seller_BasicPackage_ListViewAdapter adapter;

	String sellyearofmake, sellmodel, sellmake, sellmillage, sellprice,
			sellpicloc, sellpic, sellpicurl, sellcarid;
	String imageurl;
	JSONArray contacts1 = null;
	ArrayList<HashMap<String, String>> contactList = new ArrayList<HashMap<String, String>>();

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		// TODO Auto-generated method stub
		super.onCreate(savedInstanceState);
		if (isOnline()) {
			setContentView(R.layout.sell_package_basic);
			if(isSmartphone(Seller_Package_Standard.this)) {
				//setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_PORTRAIT);
				Toast.makeText(this, "Smartphone", Toast.LENGTH_SHORT).show();
			} else {
				Toast.makeText(this, "Tablet", Toast.LENGTH_SHORT).show();
			}
			tv_packagename = (TextView) findViewById(R.id.tv_sell_package_name);
			tv_dateofpurchase = (TextView) findViewById(R.id.tv_sell_package_purchase);
			tv_validtill = (TextView) findViewById(R.id.tv_sell_package_validtill);
			tv_postedcars = (TextView) findViewById(R.id.tv_sell_package_postedcars);
			tv_maxcars = (TextView) findViewById(R.id.tv_sell_package_maxcars);
			btn_addacar = (Button) findViewById(R.id.addacar_btn);
			packageid = Packages.package2;
			basic_lv = (ListView) findViewById(R.id.basic_lv);
			btn_sellerpackage_done = (Button) findViewById(R.id.btn_sellpackage_done);
			btn_sellerpackage_done.setOnClickListener(new OnClickListener() {

				@Override
				public void onClick(View arg0) {
					// TODO Auto-generated method stub
					finish();

				}
			});

			Intent in = getIntent();

			// String _Maxcars = null;
			// Get JSON values from previous intent
			String name = in.getStringExtra("_Maxcars2");
		//	System.out.println("max" + name);
			packaname = in.getStringExtra("Description");
			dateofpurchase = in.getStringExtra("_Dateofpurchase");
			validtill = in.getStringExtra("_vaildtill");
			postedcars = in.getStringExtra("_postedcars");
			tv_packagename.setText(packaname);
			tv_dateofpurchase.setText(dateofpurchase);
			tv_validtill.setText(validtill + "days");
			tv_postedcars.setText(postedcars);
			tv_maxcars.setText(name);

			if (postedcars.equals(name)) {
			//	System.out.println("this is no car add");
			//	System.out.println("this is no car add");
				pDialog = new ProgressDialog(this);
				pDialog.setMessage("Please wait..");
				pDialog.setIndeterminate(true);
				pDialog.setCancelable(false);
				pDialog.show();
				new MyAsyncTask().execute(url);

			} else if (!(postedcars.equals(name))) {
				btn_addacar.setVisibility(View.VISIBLE);
				btn_addacar.setOnClickListener(new OnClickListener() {

					@Override
					public void onClick(View arg0) {
						// TODO Auto-generated method stub
						Intent in = new Intent(getApplicationContext(),
								Add_A_Car.class);
						in.putExtra("Packageid", packageid);
						startActivity(in);
					}
				});
			}
			basic_lv.setOnItemClickListener(new OnItemClickListener() {

				@Override
				public void onItemClick(AdapterView<?> arg0, View view,
						int arg2, long arg3) {
					// TODO Auto-generated method stub

					Intent in = new Intent(getApplicationContext(),
							SellCarDetailView.class);
					// in.putExtra(TAG_CARID, sellcarid);
					// in.putExtra("product", product);
					TextView tv_carid = (TextView) view
							.findViewById(R.id.tv_selldisplay_carid);
					String playerChanged = tv_carid.getText().toString();
					Bundle b = new Bundle();
					b.putString("product", playerChanged);
					// in.putExtra("product", playerChanged);
					//in.putExtras(b);
					Toast.makeText(Seller_Package_Standard.this,  playerChanged,
							Toast.LENGTH_SHORT).show();
					startActivity(in);
				}
			});
		} else {
			try {

				AlertDialog alertDialog = new AlertDialog.Builder(
						Seller_Package_Standard.this).create();
				alertDialog.setTitle("Info");
				alertDialog
						.setMessage("Internet not available, Cross check your internet connectivity and try again");
				alertDialog.setIcon(R.drawable.icon);

				alertDialog.setButton("OK",
						new DialogInterface.OnClickListener() {

							@Override
							public void onClick(DialogInterface dialog,
									int which) {
								finish();
							}
						});
				alertDialog.show();
			} catch (Exception e) {

			}
		}

	}
	public static boolean isSmartphone(Activity act){
	    DisplayMetrics metrics = new DisplayMetrics();
	    act.getWindowManager().getDefaultDisplay().getMetrics(metrics);

	    int dpi = 0;
	    if (metrics.widthPixels < metrics.heightPixels){
	        dpi = (int) (metrics.widthPixels / metrics.density);
	    }
	    else{
	        dpi = (int) (metrics.heightPixels / metrics.density);
	    }

	    if (dpi < TABLET_MIN_DP_WEIGHT) {
	    	return true;
	    }
	    else {
	    	return false;
	    }
	}
	class MyAsyncTask extends
			AsyncTask<String, Integer, ArrayList<HashMap<String, String>>> {

		@Override
		protected ArrayList<HashMap<String, String>> doInBackground(
				String... arg0) {

			// TODO Auto-generated method stub

			url = "http://www.unitedcarexchange.com/MobileService/ServiceMobile.svc/FindMobileCarsByUID/"
					+ seller_carid + "/" + Uid + "/" + Uno + "/";

			// url =
			// "http://test1.unitedcarexchange.com/carservice/ServiceMobile.svc/FindMobileCarsByUID/2218/ds3lkDFD1F5fFGnf2daFs45REsd6re54yb0sc654/12345/";
		//	System.out.println("this is url");
			JSONParser jParser = new JSONParser();
			JSONObject json = jParser.getJSONFromUrl(url);
		//	System.out.println("this is json obj" + json);
			try {
				// Getting Array of Contacts
				contacts1 = json.getJSONArray("FindMobileCarsByUIDResult");
				for (int i = 0; i < contacts1.length(); i++) {
					JSONObject c = contacts1.getJSONObject(i);
					// reg_CarIDs=c.getString("CarIDs");
					String caruid = c.getString("_CarUniqueID");
					sellmake = c.getString(TAG_MAKE);
					sellmillage = c.getString(TAG_Mileage);
					sellmodel = c.getString(TAG_model);
					sellprice = c.getString(TAG_PRICE);
					sellyearofmake = c.getString(TAG_YEAR);
					sellpic = c.getString(TAG_pic);
					sellpicloc = c.getString(TAG_picloc);
					sellcarid = c.getString(TAG_CARID);

					// sellpicurl=c.getString(TAG_IMAGE);
					/*System.out.println("this is carid" + caruid);
					System.out.println("this is make" + sellmake);
					System.out.println("this is model" + sellmodel);
					System.out.println("this is year" + sellyearofmake);
					System.out.println("this is price" + sellprice);
					System.out.println("this is pic" + sellpic);
					System.out.println("this is pic loc" + sellpicloc);*/

					if (sellpicloc.equalsIgnoreCase("Emp")
							|| sellpicloc.equalsIgnoreCase(null)) {
						imageurl = "http://www.unitedcarexchange.com/"
								+ sellpic.replaceAll(" ", "%20");
					} else {
						imageurl = "http://www.unitedcarexchange.com/"
								+ sellpicloc + sellpic.replaceAll(" ", "%20");
					}
				//	System.out.println("this is image url" + imageurl);

					HashMap<String, String> map = new HashMap<String, String>();

					// adding each child node to HashMap key => value
					map.put(TAG_MAKE, sellmake);
					map.put(TAG_Mileage, sellmillage);
					map.put(TAG_model, sellmodel);
					map.put(TAG_PRICE, sellprice);
					map.put(TAG_YEAR, sellyearofmake);
					map.put(TAG_IMAGE, imageurl);
					map.put(TAG_CARID, sellcarid);

					contactList.add(map);

				}
			} catch (JSONException e) {
				e.printStackTrace();
				pDialog.cancel();
				Seller_Package_Standard.this.runOnUiThread(new Runnable() {
					public void run() {
						Toast.makeText(getApplicationContext(),
								"Server Error occured,Please try again",
								Toast.LENGTH_LONG).show();
					}
				});
			}
				catch (Exception e) {
					e.printStackTrace();
					pDialog.cancel();
					Seller_Package_Standard.this.runOnUiThread(new Runnable() {
						public void run() {
							Toast.makeText(getApplicationContext(),
									"Server Error occured,Please try again",
									Toast.LENGTH_LONG).show();
						}
					});
			}
			return null;
		}

		protected void onPostExecute(ArrayList<HashMap<String, String>> result) {

			pDialog.dismiss();

		adapter = new Seller_BasicPackage_ListViewAdapter(
					getApplicationContext(), Seller_Package_Standard.this,
					contactList);

			basic_lv.setAdapter(adapter);
		}

	}
}
