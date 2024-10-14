create database TransportManagementSystem;

-- Create Vehicles Table
CREATE TABLE Vehicle (
    VehicleID INT IDENTITY(1,1) PRIMARY KEY,
    Model VARCHAR(255),
    Capacity DECIMAL(10, 2),
    Type VARCHAR(50),  
    Status VARCHAR(50) -- (Available, On Trip, Maintenance)
);

-- Create Routes Table
CREATE TABLE Route (
    RouteID INT IDENTITY(1,1) PRIMARY KEY,
    StartDestination VARCHAR(255),
    EndDestination VARCHAR(255),
    Distance DECIMAL(10, 2)
);

-- Create Passengers Table
CREATE TABLE Passenger(
    PassengerID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName VARCHAR(255),
    Gender VARCHAR(50),
    Age INT,
    Email VARCHAR(255) UNIQUE,
    PhoneNumber BIGINT
);

-- Create Trips Table
CREATE TABLE Trip (
    TripID INT IDENTITY(1,1) PRIMARY KEY,
    VehicleID INT FOREIGN KEY REFERENCES Vehicle(VehicleID),
    RouteID INT FOREIGN KEY REFERENCES Route(RouteID),
    DepartureDate DATETIME,
    ArrivalDate DATETIME,
    Status VARCHAR(50),  -- (Scheduled, In Progress, Completed, Cancelled)
    TripType VARCHAR(50)  ,
    MaxPassengers INT
);

-- Create Drivers Table
CREATE TABLE Driver (
    DriverID INT IDENTITY(1,1) PRIMARY KEY,
    DriverName VARCHAR(255),
    TripId INT FOREIGN KEY REFERENCES Trip(TripID),
    PassengerID INT FOREIGN KEY REFERENCES Passenger(PassengerID),
    Status VARCHAR(50)  -- (Available, On Trip, Inactive)
);


-- Create Bookings Table
CREATE TABLE Booking(
    BookingID INT IDENTITY(1,1) PRIMARY KEY,
    TripID INT FOREIGN KEY REFERENCES Trip(TripID),
    PassengerID INT FOREIGN KEY REFERENCES Passenger(PassengerID),
    BookingDate DATETIME ,
    Status VARCHAR(50)  -- (Confirmed, Cancelled, Completed)
);

-- 1. Add a New Vehicle
INSERT INTO Vehicle(Model, Capacity, Type, Status) VALUES 
('Ford Transit', 15.00, 'Car', 'Available'),
('Mercedes Sprinter', 12.00, 'Car', 'On Trip'),
('Chevrolet Express', 10.00, 'Van', 'Maintenance'),
('Freightliner Cascadia', 20.00, 'Truck', 'Available'),
('Volvo VNL', 18.00, 'Truck', 'On Trip'),
('Mack Anthem', 22.00, 'Truck', 'Maintenance'),
('Bluebird Vision', 30.00, 'Bus', 'Available'),
('Thomas Built Buses', 25.00, 'Bus', 'On Trip'),
('IC Bus', 28.00, 'Bus', 'Maintenance'),
('GMC Savana', 15.00, 'Van', 'Available');

-- 2. Add a Route
INSERT INTO Route(StartDestination, EndDestination, Distance) VALUES
('New York', 'Los Angeles', 2800.00),
('Chicago', 'Houston', 1080.00),
('San Francisco', 'Seattle', 800.00),
('Miami', 'Atlanta', 660.00),
('Dallas', 'Denver', 780.00),
('Boston', 'Philadelphia', 300.00),
('Phoenix', 'Las Vegas', 300.00),
('Orlando', 'Tampa', 85.00),
('San Diego', 'Los Angeles', 120.00),
('Detroit', 'Cleveland', 170.00);

-- 3. Add a Passenger
INSERT INTO Passenger(FirstName, Gender, Age, Email, PhoneNumber) VALUES 
('John Doe', 'Male', 30, 'john.doe@example.com', 1234567890),
('Jane Smith', 'Female', 25, 'jane.smith@example.com', 2345678901),
('Alice Johnson', 'Female', 28, 'alice.johnson@example.com', 3456789012),
('Bob Brown', 'Male', 35, 'bob.brown@example.com', 4567890123),
('Charlie Davis', 'Male', 40, 'charlie.davis@example.com', 5678901234),
('Diana Evans', 'Female', 22, 'diana.evans@example.com', 6789012345),
('Ethan White', 'Male', 27, 'ethan.white@example.com', 7890123456),
('Fiona Green', 'Female', 31, 'fiona.green@example.com', 8901234567),
('George Black', 'Male', 29, 'george.black@example.com', 9012345678),
('Hannah Blue', 'Female', 26, 'hannah.blue@example.com', 1023456789);


-- 4. Schedule a Trip
INSERT INTO Trip(VehicleID, RouteID, DepartureDate, ArrivalDate, Status, TripType, MaxPassengers) VALUES 
(1, 1, '2024-10-01 ', '2024-10-02 ', 'Scheduled', 'One-way', 15),
(2, 2, '2024-10-03', '2024-10-03 ', 'In Progress', 'Round-trip', 12),
(3, 3, '2024-10-04 ', '2024-10-04 ', 'Completed', 'One-way', 10),
(4, 4, '2024-10-05 ', '2024-10-05 ', 'Cancelled', 'Round-trip', 20),
(5, 5, '2024-10-06 ', '2024-10-06 ', 'Scheduled', 'One-way', 18),
(6, 6, '2024-10-07 ', '2024-10-07 ', 'In Progress', 'Round-trip', 22),
(7, 7, '2024-10-08 ', '2024-10-08 ', 'Completed', 'One-way', 30),
(8, 8, '2024-10-09', '2024-10-09 ', 'Cancelled', 'Round-trip', 25),
(9, 9, '2024-10-10 ', '2024-10-10 ', 'Scheduled', 'One-way', 28),
(10, 10, '2024-10-11', '2024-10-11 ', 'In Progress', 'Round-trip', 15);

-- 5. Add a Driver
INSERT INTO Driver(DriverName,TripId,PassengerID, Status) VALUES 
('Michael Scott', 1, 1, 'Available'),
('Pam Beesly', 2, 2, 'On Trip'),
('Jim Halpert', 3, 3, 'Inactive'),
('Dwight Schrute', 4, 4, 'Available'),
('Angela Martin', 5, 5, 'On Trip'),
('Kevin Malone', 6, 6, 'Inactive'),
('Oscar Martinez', 7, 7, 'Available'),
('Toby Flenderson',8, 8, 'On Trip'),
('Ryan Howard', 9, 9, 'Inactive'),
('Kelly Kapoor', 10, 10, 'Available');


-- 6. Book a Trip
INSERT INTO Booking (TripID, PassengerID, BookingDate, Status) VALUES 
(1, 1, '2024-10-01 ', 'Confirmed'),
(2, 2, '2024-10-02 ', 'Cancelled'),
(3, 3, '2024-10-03 ', 'Completed'),
(4, 4, '2024-10-04 ', 'Confirmed'),
(5, 5, '2024-10-05 ', 'Cancelled'),
(6, 6, '2024-10-06 ', 'Completed'),
(7, 7, '2024-10-07 ', 'Confirmed'),
(8, 8, '2024-10-08 ', 'Cancelled'),
(9, 9, '2024-10-09 ', 'Completed'),
(10, 10, '2024-10-10 ', 'Confirmed');

-- to get the data from the table
SELECT *FROM Booking;
SELECT *FROM Vehicle;
SELECT *FROM Route;
SELECT *FROM Passenger;
SELECT *FROM Trip;
SELECT *FROM Driver;

