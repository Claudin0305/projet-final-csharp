-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : mer. 27 oct. 2021 à 10:43
-- Version du serveur :  5.7.31
-- Version de PHP : 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `hopital_espoir`
--

-- --------------------------------------------------------

--
-- Structure de la table `assurances`
--

DROP TABLE IF EXISTS `assurances`;
CREATE TABLE IF NOT EXISTS `assurances` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom_compagnie` varchar(30) NOT NULL,
  `sigle` varchar(15) NOT NULL,
  `nom_directeur` varchar(50) NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `email` varchar(100) DEFAULT NULL,
  `percent_paiment_cons` double DEFAULT NULL,
  `percent_paiment_ch` double DEFAULT NULL,
  `percent_paiment_hosp` double DEFAULT NULL,
  `etat` varchar(15) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom_compagnie` (`nom_compagnie`),
  UNIQUE KEY `telephone` (`telephone`),
  UNIQUE KEY `email` (`email`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `assurances`
--

INSERT INTO `assurances` (`id`, `nom_compagnie`, `sigle`, `nom_directeur`, `adresse`, `telephone`, `email`, `percent_paiment_cons`, `percent_paiment_ch`, `percent_paiment_hosp`, `etat`) VALUES
(1, 'Comp-1', 'FOCUS', 'Claudin Saintil', '65, rue, ville, pays', '4829-9034', '', 12, 12, 23, 'En cours');

-- --------------------------------------------------------

--
-- Structure de la table `chambres`
--

DROP TABLE IF EXISTS `chambres`;
CREATE TABLE IF NOT EXISTS `chambres` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `type_chambre` varchar(30) NOT NULL,
  `couvrir_par_assurance` varchar(10) NOT NULL,
  `prix_location` double DEFAULT NULL,
  `etat` varchar(30) NOT NULL,
  `constituants` varchar(250) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `chambres`
--

INSERT INTO `chambres` (`id`, `nom`, `type_chambre`, `couvrir_par_assurance`, `prix_location`, `etat`, `constituants`, `description`) VALUES
(1, 'CH-1', 'Privée', 'Oui', 250, 'Disponible', '2 lits', 'bla bla');

-- --------------------------------------------------------

--
-- Structure de la table `consultations`
--

DROP TABLE IF EXISTS `consultations`;
CREATE TABLE IF NOT EXISTS `consultations` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `no_dossier_patient` int(11) DEFAULT NULL,
  `consultations_pr_services` varchar(250) NOT NULL,
  `consultation_pay_ass` varchar(10) NOT NULL,
  `motif_consultation` varchar(120) NOT NULL,
  `necessite_hospita` varchar(10) NOT NULL,
  `hospitalisation_sur_ass` varchar(10) DEFAULT NULL,
  `id_chambre` int(11) DEFAULT NULL,
  `duree_hospital` int(11) DEFAULT NULL,
  `medecin_en_charge` varchar(50) DEFAULT NULL,
  `date_cons_or_hosp` varchar(20) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_patient` (`no_dossier_patient`),
  KEY `fk_ch` (`id_chambre`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `consultations`
--

INSERT INTO `consultations` (`id`, `no_dossier_patient`, `consultations_pr_services`, `consultation_pay_ass`, `motif_consultation`, `necessite_hospita`, `hospitalisation_sur_ass`, `id_chambre`, `duree_hospital`, `medecin_en_charge`, `date_cons_or_hosp`) VALUES
(1, 1, 'Maternite', 'Non', 'motif', 'Non', NULL, NULL, 0, NULL, '10/20/2021'),
(3, 1, 'Maternite', 'Oui', 'Jolie motif', 'Non', NULL, NULL, 0, NULL, '10/21/2021');

-- --------------------------------------------------------

--
-- Structure de la table `examens`
--

DROP TABLE IF EXISTS `examens`;
CREATE TABLE IF NOT EXISTS `examens` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_patient` int(11) NOT NULL,
  `date_examen` varchar(20) NOT NULL,
  `nom_examen` varchar(30) NOT NULL,
  `resultat` varchar(50) NOT NULL,
  `technicien_lab` varchar(50) NOT NULL,
  `signature_medecin` varchar(30) NOT NULL,
  `remarque` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Structure de la table `patients`
--

DROP TABLE IF EXISTS `patients`;
CREATE TABLE IF NOT EXISTS `patients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(30) NOT NULL,
  `prenom` varchar(30) NOT NULL,
  `sexe` varchar(10) NOT NULL,
  `date_naissance` varchar(30) NOT NULL,
  `age` int(11) NOT NULL,
  `compagnie_assure` varchar(30) DEFAULT NULL,
  `personne_responsable` varchar(30) NOT NULL,
  `tel_person_resp` varchar(15) NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `telephone` varchar(15) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `traitement_suiv` varchar(250) NOT NULL,
  `memo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `patients`
--

INSERT INTO `patients` (`id`, `nom`, `prenom`, `sexe`, `date_naissance`, `age`, `compagnie_assure`, `personne_responsable`, `tel_person_resp`, `adresse`, `telephone`, `email`, `traitement_suiv`, `memo`) VALUES
(1, 'Saintil', 'Claudin', 'Masculin', '05/03/1995', 26, 'Comp-1', 'Dieufait Saintil', '4481-6660', '45, rue, ville, pays', '4829-6891', NULL, 'Maternite', 'memo');

-- --------------------------------------------------------

--
-- Structure de la table `personnels`
--

DROP TABLE IF EXISTS `personnels`;
CREATE TABLE IF NOT EXISTS `personnels` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `categorie` varchar(30) NOT NULL,
  `nom` varchar(30) NOT NULL,
  `prenom` varchar(30) NOT NULL,
  `sexe` varchar(10) NOT NULL,
  `adresse` varchar(50) NOT NULL,
  `domaine_etude` varchar(30) NOT NULL,
  `niveau_etude` varchar(10) NOT NULL,
  `specialisation` varchar(30) NOT NULL,
  `nb_annee_exp` int(11) NOT NULL,
  `telephone` varchar(15) NOT NULL,
  `date_naissance` varchar(20) NOT NULL,
  `services_affectes` varchar(100) NOT NULL,
  `email` varchar(200) DEFAULT NULL,
  `nif_or_cin` varchar(20) NOT NULL,
  `etat` varchar(10) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `personnels`
--

INSERT INTO `personnels` (`id`, `categorie`, `nom`, `prenom`, `sexe`, `adresse`, `domaine_etude`, `niveau_etude`, `specialisation`, `nb_annee_exp`, `telephone`, `date_naissance`, `services_affectes`, `email`, `nif_or_cin`, `etat`) VALUES
(1, 'Informaticien(ne)', 'Saintil', 'Claudin', 'Masculin', '65, rue egalite, gonaives, Haiti', 'Sciences Informatiques', 'Licence', 'Programmation', 1, '4829-6891', '05/03/1995', 'Maternite', 'claudinsaintil@gmail.com', '456-578-316-9', 'Actif'),
(2, ' technicien(e) laboratoire', 'Louis', 'Nakisha', 'Féminin', '98, rue, ville, pays', 'Laboratoire Medical', 'Licence', 'Laboratoire', 2, '4356-8772', '02/08/2000', 'Maternite', NULL, '347-971-234-7', 'Actif'),
(3, 'Médecin', 'Augustin', 'Valencia', 'Féminin', '67, rue, pays, ville', 'Medecine', 'Licence', 'Cardiologie', 2, '3478-8902', '08/20/1996', 'Maternite', NULL, '456-892-388-9', 'Actif'),
(4, 'Electricien(e)', 'Toussaint', 'Wesly', 'Masculin', '45, rue 24 D, Cap-Haitien, Haiti', 'Electricite', 'Licence', 'electricien', 3, '4481-6660', '01/28/1996', 'Maternite', NULL, '456-893-475-8', 'Actif');

-- --------------------------------------------------------

--
-- Structure de la table `services`
--

DROP TABLE IF EXISTS `services`;
CREATE TABLE IF NOT EXISTS `services` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(30) NOT NULL,
  `prix_consultation` double DEFAULT NULL,
  `nom_chef_service` varchar(30) NOT NULL,
  `description` varchar(200) DEFAULT NULL,
  `couvrir_par_assurance` varchar(5) NOT NULL,
  `etat` varchar(5) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `nom` (`nom`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `services`
--

INSERT INTO `services` (`id`, `nom`, `prix_consultation`, `nom_chef_service`, `description`, `couvrir_par_assurance`, `etat`) VALUES
(1, 'Maternite', 300, 'Valencia Augustin', 'Service de maternite', 'Oui', 'D');

-- --------------------------------------------------------

--
-- Structure de la table `utilisateurs`
--

DROP TABLE IF EXISTS `utilisateurs`;
CREATE TABLE IF NOT EXISTS `utilisateurs` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_emp` int(11) NOT NULL,
  `pseudo` varchar(20) NOT NULL,
  `pass_word` varchar(250) NOT NULL,
  `etat` varchar(15) NOT NULL,
  `modules` varchar(200) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `pseudo` (`pseudo`),
  KEY `fk_personnel` (`id_emp`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Déchargement des données de la table `utilisateurs`
--

INSERT INTO `utilisateurs` (`id`, `id_emp`, `pseudo`, `pass_word`, `etat`, `modules`) VALUES
(1, 1, 'root', 'admin', 'Actif', 'Services,Chambres,Personnels,Contrats,Patients,Consultations,Utilisateurs'),
(2, 2, 'Demo', '1234', 'Actif', 'Chambres');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `consultations`
--
ALTER TABLE `consultations`
  ADD CONSTRAINT `fk_ch` FOREIGN KEY (`id_chambre`) REFERENCES `chambres` (`id`),
  ADD CONSTRAINT `fk_patient` FOREIGN KEY (`no_dossier_patient`) REFERENCES `patients` (`id`);

--
-- Contraintes pour la table `utilisateurs`
--
ALTER TABLE `utilisateurs`
  ADD CONSTRAINT `fk_personnel` FOREIGN KEY (`id_emp`) REFERENCES `personnels` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
