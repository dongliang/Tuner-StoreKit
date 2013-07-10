using UnityEngine;
using System.Collections.Generic;
using Prime31;
using Tuner.StoreKit;

public class TestStoreKit : MonoBehaviourGUI
{
#if UNITY_IPHONE

	void Start()
	{
		TunerStoreKitMgr.Instance.Init(new Tuner_T_StoreKitAdapter(),new string[]{"com.tuner.diamond"});
	}

	void OnGUI()
	{
		beginColumn();
		
		if( GUILayout.Button( "CanMakePayments" ) )
		{
			if (TunerStoreKitMgr.Instance.canMakePayments()) {
				Debug.Log("can make pay ment.");
			}
			else {
				Debug.Log("can't make pay ment.");
			}
		}
		
		if( GUILayout.Button( "GetProductData" ) )
		{
			TunerStoreKitMgr.Instance.requestProductData(new string[]{"com.tuner.diamond"});
		}

		endColumn( true );

		if (TunerStoreKitMgr.Instance.isProductsLoaded()) 
		{
			if( GUILayout.Button( "Purchase" ) )
			{
				TunerStoreKitMgr.Instance.Purchase("com.tuner.diamond",1);
			}

			if( GUILayout.Button( "finishPendingTransactions" ) )
			{
				TunerStoreKitMgr.Instance.finishPendingTransactions();
			}
		}
		if( GUILayout.Button( "getAllTransactions" ) )
		{
				List<StoreKitTransaction> transactions = TunerStoreKitMgr.Instance.getAllSavedTransactions();
			foreach (StoreKitTransaction item  in transactions) {

				Debug.Log("______"+item.transactionIdentifier+"______" + item.quantity + "__" + item.productIdentifier);

			}
		}
		
		
		endColumn();
	}
#endif
}
