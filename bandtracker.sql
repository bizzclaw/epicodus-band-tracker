-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'bands'
--
-- ---

DROP TABLE IF EXISTS `bands`;

CREATE TABLE `bands` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'venues'
--
-- ---

DROP TABLE IF EXISTS `venues`;

CREATE TABLE `venues` (
  `id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `name` VARCHAR(255) NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
);

-- ---
-- Table 'bands_venues'
--
-- ---

DROP TABLE IF EXISTS `bands_venues`;

CREATE TABLE `bands_venues` (
  `venues_id` INTEGER NULL DEFAULT NULL,
  `bands_id` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY ()
);

-- ---
-- Foreign Keys
-- ---

-- ALTER TABLE `bands_venues` ADD FOREIGN KEY (venues_id) REFERENCES `venues` (`id`);
-- ALTER TABLE `bands_venues` ADD FOREIGN KEY (bands_id) REFERENCES `bands` (`id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `bands` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `venues` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `bands_venues` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `bands` (`id`,`name`) VALUES
-- ('','');
-- INSERT INTO `venues` (`id`,`name`) VALUES
-- ('','');
-- INSERT INTO `bands_venues` (`venues_id`,`bands_id`) VALUES
-- ('','');
