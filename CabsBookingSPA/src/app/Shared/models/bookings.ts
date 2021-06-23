export interface Booking{
    id: number;
    email: string;
    bookingDate: Date;
    bookingTime: string;
    fromPlaceId: number;
    toPlaceId: number;
    pickupAddress: string;
    landmark: string;
    pickupDate: Date;
    pickupTime: string;
    cabTypeId: number;
    contactNo: string;
    status: string;
    fromPlace: string;
    toPlace: string;
    cabTypeName: string;
}