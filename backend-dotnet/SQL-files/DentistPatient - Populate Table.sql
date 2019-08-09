INSERT INTO `dentist`
Values (1, "Mickey Lee", "1985-11-3", "1234 Colored Road", "JohnKay@BestDentist.com", "909-408-3910, ext. 9093", "General Practice/Cleaning"), 
(2, "Ashely Kay", "1986-2-12", "909 Parkway Drive", "AshelyLee@BestDentist.com", "909-408-3910, ext. 4086", "Cavities/Root Canals"),
(3, "Smith O'Brian", "1975-6-4", "909 Ocean Lane", "SmithOBrian@BestDentist.com", "909-408-3910, ext. 9093", "Surgery");

INSERT INTO `patient`
Values(1, "Roy Carter", "1980-2-3", "6 Clear-Pond Drive", "RoyCarterE6@gmail.com", "388-123-4123", "Low", "General Checkup", 1), 
(2, "Kim Carter", "1999-7-9", "6 Clear-Pond Drive", "KimmyCarter9@gmail.com", "433-432-6885","Low", "Teeth Cleaning", 1),
(3, "Andrew Young", "2001-7-9", "687 Lily Ave", "Ayoung2019@student.com", "234-234-8776","Medium", "Cavity Removal", 2),
(4, "Bryan Rice", "1993-2-19", "389 White Bridge", "BryanRice@chapman.com", "484-432-4782","High", "Root Canal", "2"), 
(5, "Nathan Anders", "1967-5-19", "824 Castle-Tower", "AndersNathanielG9@gmail.com", "432-653-0987", "High", "Surgery", "3");

INSERT INTO `appointment`
Values (1, "2019-8-1", "9:00:00", "Irvine Office", "Check Up", 1, 1),
(2, "2019-8-1", "10:00:00", "Irvine Office", "Teeth Cleaning", 1, 2),
(3, "2019-8-1", "9:00:00", "Costa Mesa", "Cavity Removal", 2, 3), 
(4, "2019-8-2", "9:00:00", "Costa Mesa", "Root Canal Removal", 2, 4), 
(5, "2019-8-3", "9:00:00", "Costa Mesa", "Surgery Remove Bone", 3, 5),
(6, "2019-8-5", "13:00:00", "Costa Mesa", "Followup Surgery Checkup", 3, 5);

