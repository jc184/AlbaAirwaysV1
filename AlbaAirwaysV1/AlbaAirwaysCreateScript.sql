-- SQLINES DEMO *** sktop version to convert large SQL scripts,
-- SQLINES DEMO *** ny issues with Online conversion.

-- SQLINES DEMO *** act us at support@sqlines.com
-- phpMyAdmin SQL Dump
-- version 4.5.0.2
-- SQLINES DEMO *** dmin.net
--
-- Host: 127.0.0.1
-- SQLINES DEMO *** Jan 02, 2018 at 01:30 PM
-- SQLINES DEMO *** 0.0.17-MariaDB
-- PHP Version: 5.6.14

/* SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO"; */


/* SQLINES DEMO *** ARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/* SQLINES DEMO *** ARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/* SQLINES DEMO *** LLATION_CONNECTION=@@COLLATION_CONNECTION */;
/* SQLINES DEMO *** tf8mb4 */;

--
-- SQLINES DEMO *** bookingsystemv2`
--

-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `booking`
--

CREATE TABLE booking (
  [Id] int NOT NULL IDENTITY(1,1), 
  [NoOfAdults] int NOT NULL,
  [NoOfChildren] int NOT NULL,
  [NoOfInfants] int NOT NULL,
  [Amount] decimal(6,2) NOT NULL,
  [ConfirmationNo] int NOT NULL,
  [Customer_Id] int NOT NULL,
  [OutboundFlight_Id] int NOT NULL,
  [InboundFlight_Id] int DEFAULT NULL
) ;

--
-- SQLINES DEMO *** table `booking`
--
SET IDENTITY_INSERT booking ON
INSERT INTO booking ([Id], [NoOfAdults], [NoOfChildren], [NoOfInfants], [Amount], [ConfirmationNo], [Customer_Id], [OutboundFlight_Id], [InboundFlight_Id]) VALUES
(1, 2, 0, 0, '150.00', 987654321, 1, 1, 2),
(2, 12, 0, 0, '900.00', 876543219, 1, 1, 2);
SET IDENTITY_INSERT booking OFF
-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `customer`
--

CREATE TABLE customer (
  [Id] int NOT NULL IDENTITY(1,1), 
  [Title] varchar(10) NOT NULL,
  [FirstName] varchar(45) NOT NULL,
  [Surname] varchar(45) NOT NULL,
  [MobileNumber] varchar(12) NOT NULL,
  [HomePhoneNumber] varchar(12) NOT NULL,
  [EmailAddress] varchar(45) NOT NULL,
  [LoginName] varchar(45) NOT NULL,
  [LoginPassword] varchar(45) NOT NULL,
  [CardType] varchar(45) NOT NULL,
  [CardNumber] varchar(16) NOT NULL,
  [CardExpiry] date NOT NULL,
  [AddressLine1] varchar(45) NOT NULL,
  [AddressLine2] varchar(45) NOT NULL,
  [PostCode] varchar(12) NOT NULL,
  [TownCity] varchar(45) NOT NULL,
  [CountyState] varchar(45) NOT NULL,
  [Country] varchar(45) NOT NULL
) ;

--
-- SQLINES DEMO *** table `customer`
--
SET IDENTITY_INSERT customer ON
INSERT INTO customer ([Id], [Title], [FirstName], [Surname], [MobileNumber], [HomePhoneNumber], [EmailAddress], [LoginName], [LoginPassword], [CardType], [CardNumber], [CardExpiry], [AddressLine1], [AddressLine2], [PostCode], [TownCity], [CountyState], [Country]) VALUES
(1, 'mr', 'james', 'chalmers', '07552605450', '01343547869', 'james.chalmers184@gmail.com', 'jc184', '1Acheilidh1', 'VISA', '4111222233334444', '2019-09-09', '37 Forteath Avenue', 'west end', 'IV30 1TF', 'Elgin', 'Morayshire', 'UK');
SET IDENTITY_INSERT customer OFF
-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `flight`
--

CREATE TABLE flight (
  [Id] int NOT NULL IDENTITY(1,1), 
  [DepartureDateTime] datetime2(0) NOT NULL,
  [ArrivalDateTime] datetime2(0) NOT NULL,
  [FlightDate] date NOT NULL,
  [Route_Id] int NOT NULL
) ;

--
-- SQLINES DEMO *** table `flight`
--
SET IDENTITY_INSERT flight ON
INSERT INTO flight ([Id], [DepartureDateTime], [ArrivalDateTime], [FlightDate], [Route_Id]) VALUES
(1, '2017-12-12 12:00:00', '2018-12-12 12:45:00', '2017-12-12', 1),
(2, '2017-12-13 12:00:00', '2017-12-13 12:45:00', '2017-12-13', 1),
(3, '2017-12-14 12:00:00', '2017-12-14 12:45:00', '2017-12-14', 1),
(4, '2018-01-01 09:00:00', '2018-01-01 09:45:00', '2018-01-01', 1),
(5, '2018-01-01 14:00:00', '2018-01-01 14:45:00', '2018-01-01', 1),
(6, '2018-01-02 09:00:00', '2018-01-02 09:45:00', '2018-01-02', 1),
(7, '2018-01-02 14:00:00', '2018-01-02 14:45:00', '2018-01-02', 1),
(8, '2018-01-03 09:00:00', '2018-01-03 09:45:00', '2018-01-03', 1),
(9, '2018-01-03 14:00:00', '2018-01-03 14:45:00', '2018-01-03', 1),
(10, '2018-01-04 09:00:00', '2018-01-04 09:45:00', '2018-01-04', 1),
(11, '2018-01-04 14:00:00', '2018-01-04 14:45:00', '2018-01-04', 1),
(24, '2018-01-01 09:00:00', '2018-01-01 09:45:00', '2018-01-01', 2),
(25, '2018-01-01 14:00:00', '2018-01-01 14:45:00', '2018-01-01', 2),
(26, '2018-01-02 09:00:00', '2018-01-02 09:45:00', '2018-01-02', 2),
(27, '2018-01-02 14:00:00', '2018-01-02 14:45:00', '2018-01-02', 2),
(28, '2018-01-03 09:00:00', '2018-01-03 09:45:00', '2018-01-03', 2),
(29, '2018-01-03 14:00:00', '2018-01-03 14:45:00', '2018-01-03', 2),
(30, '2018-01-04 09:00:00', '2018-01-04 09:45:00', '2018-01-04', 2),
(31, '2018-01-04 14:00:00', '2018-01-04 14:45:00', '2018-01-04', 2);
SET IDENTITY_INSERT flight OFF
-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `passenger`
--

CREATE TABLE passenger (
  [Id] int NOT NULL IDENTITY(1,1), 
  [PassengerName] varchar(45) NOT NULL,
  [Booking_Id] int NOT NULL,
  [BaggageItemId] int NOT NULL,
  [BaggageItemWeightKg] int NOT NULL,
  [Seat_SeatNo] int NOT NULL,
  [Seat_Flight_Id] int NOT NULL
) ;

-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `route`
--

CREATE TABLE route (
  [Id] int NOT NULL IDENTITY(1,1), 
  [RouteName] varchar(45) NOT NULL,
  [AirportFrom] char(3) NOT NULL,
  [AirportTo] char(3) NOT NULL
) ;

--
-- SQLINES DEMO *** table `route`
--
SET IDENTITY_INSERT route ON
INSERT INTO route ([Id], [RouteName], [AirportFrom], [AirportTo]) VALUES
(1, 'Aberdeen to Kirkwall', 'ABD', 'KIR'),
(2, 'Kirkwall to Aberdeen', 'KIR', 'ABD');
SET IDENTITY_INSERT route OFF

-- SQLINES DEMO *** ---------------------------------------

--
-- SQLINES DEMO *** or table `seat`
--

CREATE TABLE seat (
  [SeatNo] int NOT NULL,
  [Flight_Id] int NOT NULL,
  [Booking_Id] int NOT NULL,
  [SeatPrice] decimal(4,2) NOT NULL
) ;

--
-- SQLINES DEMO *** table `seat`
--

INSERT INTO seat ([SeatNo], [Flight_Id], [Booking_Id], [SeatPrice]) VALUES
(0, 1, 1, '75.00'),
(0, 2, 2, '75.00'),
(0, 3, 2, '75.00'),
(1, 1, 1, '75.00'),
(1, 2, 2, '75.00'),
(1, 3, 2, '75.00'),
(2, 1, 1, '75.00'),
(2, 2, 1, '75.00'),
(2, 3, 2, '75.00'),
(3, 1, 1, '75.00'),
(3, 2, 2, '75.00'),
(5, 1, 1, '75.00'),
(5, 2, 1, '75.00'),
(6, 1, 1, '75.00'),
(6, 3, 2, '75.00'),
(7, 1, 1, '75.00'),
(8, 1, 1, '75.00'),
(8, 2, 1, '75.00'),
(9, 2, 2, '75.00'),
(10, 1, 1, '75.00'),
(11, 1, 1, '75.00'),
(11, 2, 2, '75.00'),
(11, 3, 2, '75.00'),
(12, 3, 2, '75.00'),
(16, 2, 1, '75.00'),
(16, 3, 2, '75.00'),
(17, 2, 1, '75.00'),
(23, 2, 1, '75.00');

--
-- SQLINES DEMO *** d tables
--

--
-- SQLINES DEMO ***  `booking`
--
ALTER TABLE [booking]
  ADD PRIMARY KEY ([Id]);

--
-- SQLINES DEMO ***  `customer`
--
ALTER TABLE [customer]
  ADD PRIMARY KEY ([Id]);

--
-- SQLINES DEMO ***  `flight`
--
ALTER TABLE [flight]
  ADD PRIMARY KEY ([Id]);

--
-- SQLINES DEMO ***  `passenger`
--
ALTER TABLE [passenger]
  ADD PRIMARY KEY ([Id]);

--
-- SQLINES DEMO ***  `route`
--
ALTER TABLE [route]
  ADD PRIMARY KEY ([Id]);

--
-- SQLINES DEMO ***  `seat`
--
ALTER TABLE [seat]
  ADD PRIMARY KEY ([SeatNo],[Flight_Id]);

--
-- SQLINES DEMO *** r dumped tables
--

--
-- SQLINES DEMO *** r table `booking`
--
-- SQLINES DEMO *** umped tables
--

--
-- SQLINES DEMO *** able `booking`
--
ALTER TABLE [booking]
  ADD CONSTRAINT [fk_Booking_Customer1] FOREIGN KEY ([Customer_Id]) REFERENCES customer ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [booking]
  ADD CONSTRAINT [fk_Booking_Flight1] FOREIGN KEY ([OutboundFlight_Id]) REFERENCES flight ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [booking]
  ADD CONSTRAINT [fk_Booking_Flight2] FOREIGN KEY ([InboundFlight_Id]) REFERENCES flight ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- SQLINES DEMO *** able `flight`
--
ALTER TABLE [flight]
  ADD CONSTRAINT [fk_Flight_Route1] FOREIGN KEY ([Route_Id]) REFERENCES route ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- SQLINES DEMO *** able `passenger`
--
ALTER TABLE [passenger]
  ADD CONSTRAINT [fk_Passenger_Booking1] FOREIGN KEY ([Booking_Id]) REFERENCES booking ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [passenger]
  ADD CONSTRAINT [fk_Passenger_Seat1] FOREIGN KEY ([Seat_SeatNo],[Seat_Flight_Id]) REFERENCES seat ([SeatNo], [Flight_Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;
--
-- SQLINES DEMO *** able `seat`
--
ALTER TABLE [seat]
  ADD CONSTRAINT [fk_Seat_Booking1] FOREIGN KEY ([Booking_Id]) REFERENCES booking ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE [seat]
  ADD CONSTRAINT [fk_Seat_Flight1] FOREIGN KEY ([Flight_Id]) REFERENCES flight ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION;

/* SQLINES DEMO *** ER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/* SQLINES DEMO *** ER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/* SQLINES DEMO *** ON_CONNECTION=@OLD_COLLATION_CONNECTION */;