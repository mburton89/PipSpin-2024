using UnityEngine;
using System.Collections;
using Soomla;
using Soomla.Store;
using System;  
using System.Collections.Generic; 

//namespace Soomla.Store.Example {

public class PipSpinBilling : MonoBehaviour{   
	
	//public string supportive = "";
	
	void Start () {  
		SoomlaStore.Initialize(new PipSpinAssets());       
		StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted; 
		StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;       
		StoreEvents.OnMarketPurchase += onMarketPurchase;
	
		StoreEvents.OnMarketRefund += onMarketRefund; 
		//StoreEvents.OnUnexpectedStoreError += onUnexpectedErrorInStore;
		StoreEvents.OnBillingNotSupported += onBillingNotSupported;
		StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
		StoreEvents.OnRestoreTransactionsFinished += onRestoreTransactionsFinished;
	}

	public void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra) {
		PlayerPrefs.SetInt("hasHackerEdition",1);    
		PlayerPrefs.SetInt("displayThankYou",1);
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}
	

	public void onMarketRefund(PurchasableVirtualItem pvi) {  
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}

	public void onItemPurchased(PurchasableVirtualItem pvi, string payload) {
		
	}

	public void onGoodEquipped(EquippableVG good) {
		
	}

	public void onGoodUnequipped(EquippableVG good) {
		
	}

	public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade) {
		
	}

	public void onBillingSupported() {
		
	}

	public void onBillingNotSupported() {
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}

	public void onMarketPurchaseStarted(PurchasableVirtualItem pvi) {
		PlayerPrefs.SetInt("purchaseHasStarted",1);
	}

	public void onItemPurchaseStarted(PurchasableVirtualItem pvi) {
		
	}

	public void onMarketPurchaseCancelled(PurchasableVirtualItem pvi) {
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}

	public void onUnexpectedErrorInStore(string message) {
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}

	public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
		
	}

	public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
		
	}

	public void onRestoreTransactionsStarted() {
		PlayerPrefs.SetInt("purchaseHasStarted",1);
	}

	public void onRestoreTransactionsFinished(bool success) {
		PlayerPrefs.SetInt("purchaseHasStarted",0);
	}

	public void onSoomlaStoreInitialized() {
		
	}
	
	#if UNITY_ANDROID && !UNITY_EDITOR
	public void onIabServiceStarted() {
		
	}
	public void onIabServiceStopped() {
		
	}
	#endif
}
//}
