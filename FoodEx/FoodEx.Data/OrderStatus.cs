namespace FoodEx.Data;

public enum OrderStatus
{
    Pending = 0,
    StartPreparing = 1,
    Prepared = 2,
    HandedToDelivery = 3,
    OutForDelivery = 4,
    Delivered = 5,
    Declined = 6
}
