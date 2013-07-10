using System.Collections.Generic;

namespace Tuner.StoreKit
{
		public class TunerStoreKitMgr:Tuner.Singleton<TunerStoreKitMgr>
		{
				ITunerStoreKitAdapter mAdapter = null;				
				//product data
				private List<StoreKitProduct> _products = null;
				
				public void Init (ITunerStoreKitAdapter adapter, string[] productIdentifiers)
				{
						mAdapter = adapter;
						StoreKitManager.autoConfirmTransactions = false;
						StoreKitManager.productPurchaseAwaitingConfirmationEvent += productPurchaseAwaitingConfirmationEvent;
						StoreKitManager.purchaseSuccessfulEvent += purchaseSuccessful;
						StoreKitManager.purchaseCancelledEvent += purchaseCancelled;
						StoreKitManager.purchaseFailedEvent += purchaseFailed;
						StoreKitManager.productListReceivedEvent += productListReceivedEvent;
						StoreKitManager.productListRequestFailedEvent += productListRequestFailed;
						if (canMakePayments ()) {
								requestProductData (productIdentifiers);
						}
					
				}

				public void Destory ()
				{
						StoreKitManager.productPurchaseAwaitingConfirmationEvent -= productPurchaseAwaitingConfirmationEvent;
						StoreKitManager.purchaseSuccessfulEvent -= purchaseSuccessful;
						StoreKitManager.purchaseCancelledEvent -= purchaseCancelled;
						StoreKitManager.purchaseFailedEvent -= purchaseFailed;
						StoreKitManager.productListReceivedEvent -= productListReceivedEvent;
						StoreKitManager.productListRequestFailedEvent -= productListRequestFailed;
						mAdapter = null;
				}
				
				//function
				public bool isProductsLoaded ()
				{
						return (_products != null && _products.Count > 0);
				}
				
				public bool canMakePayments ()
				{
						bool canMakePayments = StoreKitBinding.canMakePayments ();
						return canMakePayments;
				}

				public void requestProductData (string[] productIdentifiers)
				{
						StoreKitBinding.requestProductData (productIdentifiers);
				}
				
				public bool Purchase (string productIdentifier, uint quantity)
				{
						foreach (StoreKitProduct item in _products) {
								if (item.productIdentifier == productIdentifier) {
										StoreKitBinding.purchaseProduct (item.productIdentifier, (int)quantity);
										return true;
								}
						}
						return false;
				}

				public List<StoreKitTransaction> getAllSavedTransactions ()
				{
					return 	StoreKitBinding.getAllSavedTransactions ();
				}

				public void finishPendingTransaction (string transactionIdentifier)
				{
						StoreKitBinding.finishPendingTransaction (transactionIdentifier);
				}

				public void finishPendingTransactions ()
				{
						StoreKitBinding.finishPendingTransactions ();
				}

				//callback
				void productListReceivedEvent (List<StoreKitProduct> productList)
				{
						_products = productList;
						if (mAdapter != null) {
								mAdapter.productListReceivedEvent (productList);
						}
				}
		
				void productListRequestFailed (string error)
				{
						if (mAdapter != null) {
								mAdapter.productListRequestFailed (error);
						}
				}
		
				void purchaseFailed (string error)
				{
						if (mAdapter != null) {
								mAdapter.purchaseFailed (error);
						}
				}
		
				void purchaseCancelled (string error)
				{
						if (mAdapter != null) {
								mAdapter.purchaseCancelled (error);
						}
				}
		
				void productPurchaseAwaitingConfirmationEvent (StoreKitTransaction transaction)
				{
						if (mAdapter != null) {
								mAdapter.productPurchaseAwaitingConfirmationEvent (transaction);
						}
				}
		
				void purchaseSuccessful (StoreKitTransaction transaction)
				{
						if (mAdapter != null) {
								mAdapter.purchaseSuccessful (transaction);
						}						
				}
		}
}