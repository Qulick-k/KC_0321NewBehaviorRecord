using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter {


    public static DeliveryCounter Instance { get; private set; }
    private int Judge = 6;

    private void Awake() {
        Instance = this;
    }


    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject)) {
                // Only accepts Plates

                DeliveryManager.Instance.DeliverRecipe(plateKitchenObject);
                GameHandler.SaveInteract(Judge);

                KitchenObject.DestroyKitchenObject(player.GetKitchenObject());
            }
        }
    }

}