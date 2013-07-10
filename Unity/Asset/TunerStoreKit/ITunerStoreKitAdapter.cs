using System.Collections.Generic;

namespace Tuner.StoreKit
{
		public interface ITunerStoreKitAdapter
		{
				void productListReceivedEvent (List<StoreKitProduct> productList);
		
				void productListRequestFailed (string error);
		
				void purchaseFailed (string error);
		
				void purchaseCancelled (string error);
		
				void productPurchaseAwaitingConfirmationEvent (StoreKitTransaction transaction);
		
				void purchaseSuccessful (StoreKitTransaction transaction);

		}
}