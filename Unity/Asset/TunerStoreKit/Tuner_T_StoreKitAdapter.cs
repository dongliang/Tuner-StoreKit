using System;
using System.Collections.Generic;
using UnityEngine;
using Tuner.StoreKit;

public class Tuner_T_StoreKitAdapter:ITunerStoreKitAdapter
{
		public Tuner_T_StoreKitAdapter ()
		{
		}

	public	void productListReceivedEvent (List<StoreKitProduct> productList)
		{
				Debug.Log ("productListReceivedEvent. total products received: " + productList.Count);
		
				// print the products to the console
				foreach (StoreKitProduct product in productList) {
						Debug.Log (product.ToString () + "\n");
				}
		}
	
	public	void productListRequestFailed (string error)
		{
				Debug.Log ("productListRequestFailed: " + error);
		}
	
	public	void purchaseFailed (string error)
		{
				Debug.Log ("purchase failed with error: " + error);
		}
	
	public	void purchaseCancelled (string error)
		{
				Debug.Log ("purchase cancelled with error: " + error);
		}
	
	public	void productPurchaseAwaitingConfirmationEvent (StoreKitTransaction transaction)
		{
				Debug.Log ("productPurchaseAwaitingConfirmationEvent: " + transaction);
		}
	
	public	void purchaseSuccessful (StoreKitTransaction transaction)
		{
				Debug.Log ("purchased product: " + transaction);
		}
	
	public	void restoreTransactionsFailed (string error)
		{
				Debug.Log ("restoreTransactionsFailed: " + error);
		}
	
	public	void restoreTransactionsFinished ()
		{
				Debug.Log ("restoreTransactionsFinished");
		}
}


