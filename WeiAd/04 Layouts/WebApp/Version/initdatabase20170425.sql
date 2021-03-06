USE [WeiAd]
GO
/****** Object:  Table [dbo].[AccountInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NULL,
	[NickName] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [varchar](50) NULL,
	[UserType] [int] NOT NULL,
	[UserPwd] [varchar](50) NULL,
	[UserImg] [varchar](50) NULL,
	[RegDate] [datetime] NOT NULL,
	[RegIp] [varchar](50) NULL,
	[IsLock] [int] NOT NULL,
	[LastLoginDate] [datetime] NOT NULL,
	[AccountType] [int] NOT NULL,
	[OpenId] [varchar](100) NULL,
	[ConsumptionMoney] [float] NOT NULL,
	[Money] [float] NOT NULL,
	[MoneyFree] [float] NOT NULL,
	[MoneyCount] [float] NOT NULL,
	[LastMoneyDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AccountInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdBrowse]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdBrowse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](500) NULL,
	[ClientIp] [varchar](50) NULL,
	[BrowseType] [varchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[FlowUserId] [int] NOT NULL,
	[AdUrl] [varchar](500) NULL,
	[Money] [money] NOT NULL,
	[IsMoney] [int] NOT NULL,
	[Time] [int] NOT NULL,
	[ClientId] [varchar](100) NULL,
	[IsMobile] [int] NOT NULL,
	[ReferrerUrl] [varchar](1000) NULL,
	[BrowseName] [varchar](100) NULL,
	[BrowseVersion] [varchar](100) NULL,
	[OsName] [varchar](100) NULL,
 CONSTRAINT [PK_AdBrowse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdBrowseHistory]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdBrowseHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](500) NULL,
	[ClientIp] [varchar](50) NULL,
	[BrowseType] [varchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[FlowUserId] [int] NOT NULL,
	[AdUrl] [varchar](500) NULL,
	[Money] [money] NOT NULL,
	[IsMoney] [int] NOT NULL,
	[Time] [int] NOT NULL,
	[ClientId] [varchar](100) NULL,
	[IsMobile] [int] NOT NULL,
	[ReferrerUrl] [varchar](1000) NULL,
	[BrowseName] [varchar](100) NULL,
	[BrowseVersion] [varchar](100) NULL,
	[OsName] [varchar](100) NULL,
 CONSTRAINT [PK_AdBrowseHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdPageInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdPageInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WeiXinUrl] [varchar](500) NULL,
	[Title] [varchar](500) NULL,
	[TitleImg] [varchar](4000) NULL,
	[QcodeImg] [varchar](500) NULL,
	[Content] [text] NULL,
	[AdType] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[UserId] [int] NOT NULL,
	[ViewPage] [varchar](500) NULL,
	[UserCodeId] [int] NOT NULL,
	[UserCodeIds] [varchar](500) NULL,
	[IsState] [int] NOT NULL,
	[Money] [money] NOT NULL,
	[SaleType] [int] NOT NULL,
	[PlanIp] [int] NOT NULL CONSTRAINT [DF__AdPageInf__PlanI__19AACF41]  DEFAULT ((0)),
	[StartTime] [datetime] NOT NULL CONSTRAINT [DF__AdPageInf__Start__1A9EF37A]  DEFAULT (getdate()),
	[PlanTerminal] [int] NOT NULL CONSTRAINT [DF__AdPageInf__PlanT__1F63A897]  DEFAULT ((0)),
	[MoneyCount] [money] NOT NULL CONSTRAINT [DF__AdPageInf__Money__2057CCD0]  DEFAULT ((0)),
	[BuyMoney] [money] NOT NULL CONSTRAINT [DF__AdPageInf__BuyMo__214BF109]  DEFAULT ((0)),
	[OrderIndex] [int] NOT NULL CONSTRAINT [DF__AdPageInf__Order__22401542]  DEFAULT ((0)),
	[UserCode] [varchar](2000) NULL,
	[TitleShort] [varchar](2000) NULL,
	[BuyIp] [int] NOT NULL DEFAULT ((0)),
	[TemplateName] [varchar](200) NULL,
	[IsDel] [int] NOT NULL DEFAULT ((0)),
	[IsAuth] [int] NOT NULL DEFAULT ((0)),
	[StaticContent] [varchar](4000) NULL,
	[CreateUserId] [int] NOT NULL DEFAULT ((0)),
	[MiddlePage] [varchar](500) NULL,
	[AdTimeStart] [varchar](50) NULL,
	[AdTimeEnd] [varchar](50) NULL,
	[UserAdTypeId] [int] NOT NULL DEFAULT ((0)),
	[Desc] [varchar](500) NULL,
	[SiteTypeId] [int] NOT NULL DEFAULT ((0)),
	[PlatformType] [varchar](50) NULL,
	[DeleteDate] [datetime] NOT NULL DEFAULT (getdate()),
	[DefaultQcode] [varchar](500) NULL,
	[QcodeCount] [int] NOT NULL DEFAULT ((0)),
	[PageCount] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_AdPageInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdQcodeInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdQcodeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[Name] [varchar](500) NULL,
	[QcodeUrl] [varchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
 CONSTRAINT [PK_AdQcodeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdSiteInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdSiteInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[Desc] [varchar](2000) NULL,
	[WebSite] [varchar](1000) NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[PlatformType] [varchar](500) NULL,
	[Contact] [varchar](500) NULL,
 CONSTRAINT [PK_AdSiteInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdTypeInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdTypeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Desc] [varchar](500) NULL,
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AdTypeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AdUserPage]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AdUserPage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Gid] [varchar](100) NULL,
	[PageName] [varchar](100) NULL,
	[AdPageId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[IsState] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[FlowUserId] [int] NOT NULL,
	[FlowLastDate] [datetime] NOT NULL,
 CONSTRAINT [PK_AdUserPage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticleInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticleInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ChannelId] [int] NOT NULL,
	[ArticleTypeId] [int] NOT NULL,
	[Title] [varchar](500) NULL,
	[TitleImg] [varchar](500) NULL,
	[TitleShort] [varchar](500) NULL,
	[LinkUrl] [varchar](500) NULL,
	[PageKey] [varchar](500) NULL,
	[PageDesc] [varchar](500) NULL,
	[ConetntShort] [varchar](500) NULL,
	[Content] [text] NULL,
	[ContentGroup] [varchar](20) NULL,
	[Lable] [varchar](200) NULL,
	[Source] [varchar](200) NULL,
	[EditUser] [varchar](20) NULL,
	[IsContributions] [int] NOT NULL,
	[IsState] [int] NOT NULL,
	[IsShow] [int] NOT NULL,
	[ContributionsUserId] [int] NOT NULL,
	[OrderIndex] [int] NOT NULL,
	[IsHot] [int] NOT NULL,
	[IsHeadline] [int] NOT NULL,
	[IsTop] [int] NOT NULL,
	[OpenCount] [int] NOT NULL,
	[CommentCount] [int] NOT NULL,
	[LikeCount] [int] NOT NULL,
	[StepCount] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[LastDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[AuditUserId] [int] NOT NULL,
	[AuditState] [int] NOT NULL,
	[AuditDate] [datetime] NOT NULL,
	[AuditDesc] [varchar](200) NULL,
	[IsAd] [int] NOT NULL,
 CONSTRAINT [PK_ArticleInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DomainInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DomainInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Domain] [varchar](100) NULL,
	[PageName] [varchar](100) NULL,
	[IsState] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ColseDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[CloseUserId] [int] NOT NULL,
	[CityName] [varchar](200) NULL,
	[IsAuth] [int] NOT NULL DEFAULT ((0)),
	[AdUserId] [int] NOT NULL DEFAULT ((0)),
 CONSTRAINT [PK_DomainInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogAdQcode]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogAdQcode](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[QcodeId] [int] NOT NULL,
	[Url] [varchar](500) NULL,
	[ClientIp] [varchar](50) NULL,
	[BrowseType] [varchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[Time] [int] NOT NULL,
	[ClientId] [varchar](100) NULL,
	[IsMobile] [int] NOT NULL,
	[ReferrerUrl] [varchar](1000) NULL,
	[BrowseName] [varchar](100) NULL,
	[BrowseVersion] [varchar](100) NULL,
	[OsName] [varchar](100) NULL,
 CONSTRAINT [PK_LogAdQcode] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogBrowse]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogBrowse](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Url] [varchar](500) NULL,
	[ClientIp] [varchar](50) NULL,
	[BrowseType] [varchar](500) NULL,
	[CreateDate] [datetime] NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUserId] [int] NOT NULL,
	[FlowUserId] [int] NOT NULL,
	[AdUrl] [varchar](500) NULL,
	[Money] [money] NOT NULL,
	[IsMoney] [int] NOT NULL,
	[Time] [int] NOT NULL,
	[ClientId] [varchar](100) NULL,
	[IsMobile] [int] NOT NULL,
	[ReferrerUrl] [varchar](1000) NULL,
	[BrowseName] [varchar](100) NULL,
	[BrowseVersion] [varchar](100) NULL,
	[OsName] [varchar](100) NULL,
 CONSTRAINT [PK_LogBrowse] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LogLogin]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LogLogin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginName] [varchar](50) NULL,
	[LoginState] [int] NOT NULL,
	[LoginDesc] [varchar](500) NULL,
	[LoginDate] [datetime] NOT NULL,
	[ClientIp] [varchar](50) NULL,
	[BrowseType] [varchar](500) NULL,
	[LoginType] [int] NOT NULL,
 CONSTRAINT [PK_LogLogin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlayHistory]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlayHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AdUserId] [int] NOT NULL,
	[FlowUserId] [int] NOT NULL,
	[AdId] [int] NOT NULL,
	[AdUrl] [varchar](500) NULL,
	[Time] [int] NOT NULL,
	[Money] [money] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
	[ClientIp] [int] NOT NULL,
	[ClientUv] [int] NOT NULL,
	[ClientPv] [int] NOT NULL,
	[Price] [money] NOT NULL,
 CONSTRAINT [PK_PlayHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserCodeInfo]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserCodeInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[UserId] [int] NOT NULL,
	[TypeId] [int] NOT NULL,
	[CodeContent] [varchar](4000) NULL,
	[CreateDate] [datetime] NOT NULL,
 CONSTRAINT [PK_UserCodeInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserFinanceHistory]    Script Date: 2017-04-25 23:18:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserFinanceHistory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[RechargeType] [int] NOT NULL,
	[Money] [money] NOT NULL,
	[MoneyType] [int] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CreateUserId] [int] NOT NULL,
 CONSTRAINT [PK_UserFinanceHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [WeiAd] SET  READ_WRITE 
GO
