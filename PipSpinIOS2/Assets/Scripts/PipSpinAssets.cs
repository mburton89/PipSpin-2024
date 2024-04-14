using UnityEngine;
using System.Collections;
using System;  
using System.Collections.Generic; 

namespace Soomla.Store {
	
	public class PipSpinAssets : IStoreAssets{
		
		public int GetVersion() {
			return 0;
		}  

		public VirtualCurrency[] GetCurrencies() {
			return new VirtualCurrency[]{};           
		}
		 
		public VirtualGood[] GetGoods() { 
			return new VirtualGood[] {
				HACKER_EDITION
			};
		}  

		public VirtualCurrencyPack[] GetCurrencyPacks() {
			return new VirtualCurrencyPack[] {};
		}
		

		public VirtualCategory[] GetCategories() {
			return new VirtualCategory[]{};  
		}
		
//		public VirtualCategory[] GetNonConsumableItems(){
//			return new LifetimeVG[] {};
//		}  

		public const string HACKER_EDITION_ID = "hackereditionpipspin";  
        //public const string HACKER_EDITION_ID = "android.test.purchased";  

		//public const string REMOVE_ADS_ID = "android.test.purchased";   

		public static VirtualGood HACKER_EDITION = new LifetimeVG( 
			"Hacker Edition",                                 // name
			"Enable Color switching. Disable ads.", 		  // description
			"hackereditionpipspin",                           // item id
			new PurchaseWithMarket(HACKER_EDITION_ID, 0.99)); // the way this virtual good is purchased
	}    
}