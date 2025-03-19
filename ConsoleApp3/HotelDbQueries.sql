-- H�mta alla bokningar
SELECT * FROM Bookings;

-- H�mta alla kunder som har bokningar
SELECT c.Name, b.CheckInDate, b.CheckOutDate
FROM Customers c
JOIN Bookings b ON c.Id = b.CustomerId;

-- H�mta alla rum som �r lediga mellan tv� datum
SELECT r.Type
FROM Rooms r
WHERE r.Id NOT IN (
    SELECT b.RoomId 
    FROM Bookings b
    WHERE b.CheckInDate <= '2025-04-01' AND b.CheckOutDate >= '2025-03-25'
);
