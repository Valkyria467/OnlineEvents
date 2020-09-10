CREATE TABLE [dbo].[Event] (
    [idEvent]   INT           IDENTITY (1, 1) NOT NULL,
	[infoevent] VARCHAR (5000) NOT NULL,
    [nameEvent] VARCHAR (500) NOT NULL,
    [typeEvent] INT           NOT NULL,
    [amount]    INT           NOT NULL,
    [dateEvent] DATETIME      NOT NULL,
    [dateStart] DATETIME      NOT NULL,
    [organizer] INT           NOT NULL,
    [city]      VARCHAR (280) NOT NULL,
    [sreet]     VARCHAR (280) NOT NULL,
    [house]     VARCHAR (10)  NULL,
    [cost]      SMALLMONEY    NULL,

    PRIMARY KEY CLUSTERED ([idEvent] ASC),
    FOREIGN KEY ([typeEvent]) REFERENCES [dbo].[TypeEvent] ([idType]),
    FOREIGN KEY ([organizer]) REFERENCES [dbo].[User] ([idUser])
);


