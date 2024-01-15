Database: `telefonskiadresar`
--

-- --------------------------------------------------------

--
-- Table structure for table `korisnici`
--

DROP TABLE IF EXISTS `korisnici`;
CREATE TABLE IF NOT EXISTS `korisnici` (
  `ime` varchar(30) COLLATE utf32_croatian_ci NOT NULL,
  `prezime` varchar(30) COLLATE utf32_croatian_ci NOT NULL,
  `adresa` varchar(50) COLLATE utf32_croatian_ci NOT NULL,
  `telefonski_broj` varchar(12) COLLATE utf32_croatian_ci NOT NULL,
  UNIQUE KEY `telefonski_broj` (`telefonski_broj`)
) ENGINE=MyISAM DEFAULT CHARSET=utf32 COLLATE=utf32_croatian_ci;

--
-- Dumping data for table `korisnici`
--

INSERT INTO `korisnici` (`ime`, `prezime`, `adresa`, `telefonski_broj`) VALUES
('Igor', 'Marković', 'Preradovićeva 9C Pula', '0958746521'),
('Marin', 'Budić', 'Preradovićeva 9C Pula', '0916548745'),
('Dino', 'Lukić', 'Preradovićeva 9C Pula', '0974521658'),
('David', 'Soldatić', 'Preradovićeva 9C Pula', '0912569874');
COMMIT;
