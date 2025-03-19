-- Hämta alla bokningar
SELECT * FROM Bookings;

-- Hämta alla kunder som har bokningar
SELECT c.Name, b.CheckInDate, b.CheckOutDate
FROM Customers c
JOIN Bookings b ON c.Id = b.CustomerId;

-- Hämta alla rum som är lediga mellan två datum
SELECT r.Type
FROM Rooms r
WHERE r.Id NOT IN (
    SELECT b.RoomId 
    FROM Bookings b
    WHERE b.CheckInDate <= '2025-04-01' AND b.CheckOutDate >= '2025-03-25'
);
