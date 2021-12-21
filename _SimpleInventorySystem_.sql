-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 08, 2021 at 04:03 AM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `simpleinventorysystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `id` int(11) NOT NULL,
  `customerName` varchar(150) NOT NULL,
  `email` varchar(100) NOT NULL,
  `phone` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`id`, `customerName`, `email`, `phone`) VALUES
(2, 'Gaurav', 'gaurav@gmail.com', '9852365452'),
(7, 'Sudip Rai', 'sudip@gmail.com', '9842365236');

-- --------------------------------------------------------

--
-- Table structure for table `product`
--

CREATE TABLE `product` (
  `id` int(11) NOT NULL,
  `barCode` varchar(200) NOT NULL,
  `name` varchar(200) NOT NULL,
  `categoryId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `product`
--

INSERT INTO `product` (`id`, `barCode`, `name`, `categoryId`) VALUES
(1, 'B102565', 'Samsung j4', 7),
(4, 'B60123', 'Samsung4', 7),
(9, 'B552266', 'Oneplus8', 8);

-- --------------------------------------------------------

--
-- Table structure for table `productcatagory`
--

CREATE TABLE `productcatagory` (
  `id` int(11) NOT NULL,
  `productName` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `productcatagory`
--

INSERT INTO `productcatagory` (`id`, `productName`) VALUES
(7, 'Samsung'),
(8, 'Oneplus');

-- --------------------------------------------------------

--
-- Table structure for table `purchasebill`
--

CREATE TABLE `purchasebill` (
  `billNo` varchar(11) NOT NULL,
  `supplierId` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unitPrice` float NOT NULL,
  `purchaseDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `purchasebill`
--

INSERT INTO `purchasebill` (`billNo`, `supplierId`, `productId`, `quantity`, `unitPrice`, `purchaseDate`) VALUES
('B1', 14, 4, 20, 18000, '2021-06-07'),
('B2', 13, 4, 20, 15000, '2021-06-06');

-- --------------------------------------------------------

--
-- Table structure for table `sales`
--

CREATE TABLE `sales` (
  `billNo` int(11) NOT NULL,
  `customerId` int(11) NOT NULL,
  `productId` int(11) NOT NULL,
  `quantity` int(11) NOT NULL,
  `unitPrice` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `sales`
--

INSERT INTO `sales` (`billNo`, `customerId`, `productId`, `quantity`, `unitPrice`) VALUES
(10, 2, 4, 13, 25000),
(15, 7, 9, 1, 75500),
(21, 7, 1, 2, 20000),
(21, 7, 9, 1, 70000),
(23, 7, 1, 1, 30000);

-- --------------------------------------------------------

--
-- Table structure for table `salesbillcount`
--

CREATE TABLE `salesbillcount` (
  `pBillNo` int(11) NOT NULL,
  `salesDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `salesbillcount`
--

INSERT INTO `salesbillcount` (`pBillNo`, `salesDate`) VALUES
(10, '2021-06-07'),
(15, '2021-06-07'),
(21, '2021-06-08'),
(22, '2021-06-08'),
(23, '2021-06-08'),
(24, '2021-06-08'),
(25, '2021-06-08'),
(26, '2021-06-08');

-- --------------------------------------------------------

--
-- Table structure for table `supplier`
--

CREATE TABLE `supplier` (
  `id` int(11) NOT NULL,
  `supplierName` varchar(150) NOT NULL,
  `email` varchar(150) NOT NULL,
  `phone` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `supplier`
--

INSERT INTO `supplier` (`id`, `supplierName`, `email`, `phone`) VALUES
(13, 'Hari', 'Parsai2@gmail.com', '9852365422'),
(14, 'Sujan Tamang', 'sujan@gmail.com', '9842653226');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `ucEmail` (`email`),
  ADD UNIQUE KEY `ucPhone` (`phone`);

--
-- Indexes for table `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `barCode` (`barCode`),
  ADD KEY `FK_ProductCategory` (`categoryId`);

--
-- Indexes for table `productcatagory`
--
ALTER TABLE `productcatagory`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `purchasebill`
--
ALTER TABLE `purchasebill`
  ADD PRIMARY KEY (`billNo`,`productId`),
  ADD KEY `FK_PurchaseProduct` (`productId`),
  ADD KEY `FK_PurchaseSupplier` (`supplierId`);

--
-- Indexes for table `sales`
--
ALTER TABLE `sales`
  ADD PRIMARY KEY (`billNo`,`productId`),
  ADD KEY `FK_SalesProductId` (`productId`),
  ADD KEY `FK_CustomerSales` (`customerId`);

--
-- Indexes for table `salesbillcount`
--
ALTER TABLE `salesbillcount`
  ADD PRIMARY KEY (`pBillNo`);

--
-- Indexes for table `supplier`
--
ALTER TABLE `supplier`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `email` (`email`) USING BTREE,
  ADD UNIQUE KEY `UC_Email` (`email`),
  ADD UNIQUE KEY `UC_Phone` (`phone`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `product`
--
ALTER TABLE `product`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `productcatagory`
--
ALTER TABLE `productcatagory`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT for table `salesbillcount`
--
ALTER TABLE `salesbillcount`
  MODIFY `pBillNo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;

--
-- AUTO_INCREMENT for table `supplier`
--
ALTER TABLE `supplier`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `product`
--
ALTER TABLE `product`
  ADD CONSTRAINT `FK_ProductCategory` FOREIGN KEY (`categoryId`) REFERENCES `productcatagory` (`id`);

--
-- Constraints for table `purchasebill`
--
ALTER TABLE `purchasebill`
  ADD CONSTRAINT `FK_PurchaseProduct` FOREIGN KEY (`productId`) REFERENCES `product` (`id`),
  ADD CONSTRAINT `FK_PurchaseSupplier` FOREIGN KEY (`supplierId`) REFERENCES `supplier` (`id`);

--
-- Constraints for table `sales`
--
ALTER TABLE `sales`
  ADD CONSTRAINT `FK_CustomerSales` FOREIGN KEY (`customerId`) REFERENCES `customer` (`id`),
  ADD CONSTRAINT `FK_SalesProductId` FOREIGN KEY (`productId`) REFERENCES `product` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
