USE [RentalManagementDB]
GO

/****** Object:  Table [dbo].[Payment]    Script Date: 4/30/2017 4:42:03 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Payment](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[PropertyID] [int] NOT NULL,
	[TenantID] [int] NOT NULL,
	[TypeID] [int] NOT NULL,
	[AmountDue] [decimal](7, 2) NOT NULL,
	[DueDate] [datetime] NOT NULL,
	[PaymentAmount] [decimal](7, 2) NULL,
	[PaymentDate] [datetime] NULL,
	[Balance] [decimal](7, 2) NOT NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


