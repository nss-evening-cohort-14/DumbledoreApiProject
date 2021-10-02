--drop table [services];
--drop table skills;
--drop table spy;
--drop table spyduhmembers;
--drop table friendsjoin;

	-- create spy table
CREATE TABLE dbo.Spy
	(
	Id uniqueidentifier NOT NULL default(newsequentialid()),
	Alias varchar(50) NOT NULL,
	AboutMe varchar(200) NOT NULL,
	CONSTRAINT PK_Spy_SpyId PRIMARY KEY CLUSTERED (Id)
	)
	;

	-- create spyduh members table with primary id key
CREATE TABLE dbo.SpyDuhMembers
	(
	Id uniqueidentifier NOT NULL default(newsequentialid()),
	Alias varchar(50) NOT NULL,
	AboutMe varchar(200) NOT NULL
	CONSTRAINT PK_SpyDuhMembers_SpuDuhMembersId PRIMARY KEY CLUSTERED (Id)
	);

--create Friends table
create table Friends (
	Id uniqueidentifier NOT NULL Primary Key default(newsequentialid()),
	SpyDuhMemberId uniqueIdentifier NOT NULL,
	FriendsId uniqueIdentifier NOT NULL,
	FriendsAlias varchar(50) NOT NULL
	CONSTRAINT FK_Friends_SpyDuhMembers FOREIGN KEY (SpyDuhMemberId)
		REFERENCES SpyDuhMembers (Id)
	)

	--create Skills table
CREATE TABLE dbo.Skills
	(
	Id uniqueidentifier NOT NULL default(newsequentialid()),
	Skill varchar(50) NOT NULL,
	CONSTRAINT PK_Skills_SkillId PRIMARY KEY CLUSTERED (Id) 
	)
	;

	--create Services table
CREATE TABLE dbo.[Services]
	(
	Id uniqueidentifier NOT NULL default(newsequentialid()),
	[Services] varchar(50) NOT NULL,
	CONSTRAINT PK_Services_ServicesId PRIMARY KEY CLUSTERED (Id)
	)
	;

-- create Affiliation join table
CREATE TABLE dbo.Affiliation
	(
	Id uniqueidentifier NOT NULL Primary Key default(newsequentialid()),
	MemberId uniqueidentifier NOT NULL,
	FriendId uniqueidentifier NOT NULL,
	Affiliation bit NOT NULL, -- is 1 for friend and 0 for enemy
	CONSTRAINT FK_AffiliationMemberId_SpyDuhMemberId FOREIGN KEY (MemberId)
		REFERENCES dbo.SpyDuhMembers (Id),
	CONSTRAINT FK_FriendId_SpyDuhMemberId FOREIGN KEY (FriendId)
		REFERENCES dbo.SpyDuhMembers (Id)
	)

-- Affiliation.Affiliation field renders the need for this table pointless
-- create Enemies join table
/*CREATE TABLE dbo.EnemiesJoin
	(
	Id uniqueidentifier NOT NULL Primary Key default(newsequentialid()),
	MemberId uniqueidentifier NOT NULL,
	EnemyId uniqueidentifier NOT NULL,
	CONSTRAINT FK_MemberId_SpyduhMemberId_Enemies FOREIGN KEY (MemberId)
		REFERENCES dbo.SpyDuhMembers (Id),
	CONSTRAINT FK_EnemyId_SpyduhMemberId FOREIGN KEY (EnemyId)
		REFERENCES dbo.SpyDuhMembers (Id)
	)
*/
-- create Skills join table
CREATE TABLE dbo.SkillsJoin
	(
	Id uniqueidentifier NOT NULL Primary Key default(newsequentialid()),
	MemberId uniqueidentifier NOT NULL,
	SkillId uniqueidentifier NOT NULL,
	CONSTRAINT FK_SkillsMemberId_SpyDuhMembersId FOREIGN KEY (MemberId)
		REFERENCES dbo.SpyDuhMembers (Id),
	CONSTRAINT FK_SkillId_SkillsId FOREIGN KEY (SkillId)
		REFERENCES dbo.Skills (Id)
	)

--create Services join table
CREATE TABLE dbo.ServicesJoin
	(
	Id uniqueidentifier NOT NULL Primary Key default(newsequentialid()),
	MemberId uniqueidentifier NOT NULL,
	ServiceId uniqueidentifier NOT NULL,
	CONSTRAINT FK_ServicesMemberId_SpyDuhMembersId FOREIGN KEY (MemberId)
		REFERENCES dbo.SpyDuhMembers (Id),
	CONSTRAINT FK_ServiceId_ServicesId FOREIGN KEY (ServiceId)
		REFERENCES dbo.[Services] (Id)
	)





