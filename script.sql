USE [FourN6]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Affairs]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Affairs](
	[affairid] [int] IDENTITY(1,1) NOT NULL,
	[affairname] [nvarchar](max) NULL,
	[affairtag] [int] NULL,
	[starttimeplan] [datetime2](7) NOT NULL,
	[endtimeplan] [datetime2](7) NOT NULL,
	[starttimeactual] [datetime2](7) NULL,
	[endtimeactual] [datetime2](7) NULL,
	[status] [int] NULL,
	[userid] [int] NULL,
	[notemember] [nvarchar](max) NULL,
	[noteleader] [nvarchar](max) NULL,
	[projectid] [int] NULL,
	[typeofaffair] [int] NULL,
 CONSTRAINT [PK_Affairs] PRIMARY KEY CLUSTERED 
(
	[affairid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AnswerActives]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AnswerActives](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[ExaminationQuestionsActiveId] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[IsCorrect] [bit] NULL,
	[IsMultipleAnswer] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_AnswerActives] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Answers]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Answers](
	[AnswerId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[QuestionId] [int] NULL,
	[IsCorrect] [bit] NULL,
	[IsMultipleAnswer] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime2](7) NULL,
 CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED 
(
	[AnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authapplication]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authapplication](
	[authapplicationid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[displayname] [nvarchar](max) NULL,
 CONSTRAINT [PK_Authapplication] PRIMARY KEY CLUSTERED 
(
	[authapplicationid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authcontroller]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authcontroller](
	[authcontrollerid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[display] [nvarchar](max) NULL,
	[iconclass] [nvarchar](max) NULL,
	[authapplicationid] [int] NOT NULL,
 CONSTRAINT [PK_Authcontroller] PRIMARY KEY CLUSTERED 
(
	[authcontrollerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authuser]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authuser](
	[authappliactionid] [int] NOT NULL,
	[userid] [int] NOT NULL,
 CONSTRAINT [PK_Authuser] PRIMARY KEY CLUSTERED 
(
	[authappliactionid] ASC,
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Authuserrole]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authuserrole](
	[authapplicationid] [int] NOT NULL,
	[userroleid] [int] NOT NULL,
 CONSTRAINT [PK_Authuserrole] PRIMARY KEY CLUSTERED 
(
	[authapplicationid] ASC,
	[userroleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Chatroom]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Chatroom](
	[chatroomid] [int] IDENTITY(1,1) NOT NULL,
	[chatuserid] [int] NULL,
	[chatusercontent] [nvarchar](max) NULL,
	[chatusergroup] [int] NULL,
	[chatusercreateat] [nvarchar](max) NULL,
	[chatuserupdateat] [nvarchar](50) NULL,
 CONSTRAINT [PK_Chatroom] PRIMARY KEY CLUSTERED 
(
	[chatroomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departmentpartner]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departmentpartner](
	[departmentpartnerid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[desc] [nvarchar](max) NULL,
	[duration] [int] NOT NULL,
	[timeend] [datetime2](7) NOT NULL,
	[department] [int] NOT NULL,
	[img] [nvarchar](max) NULL,
	[status] [int] NULL,
	[shortdesc] [nvarchar](max) NULL,
	[examid] [int] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Departmentpartner] PRIMARY KEY CLUSTERED 
(
	[departmentpartnerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Documents](
	[docid] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NULL,
	[authorrole] [int] NULL,
	[authorname] [nvarchar](max) NULL,
	[files] [nvarchar](max) NULL,
	[note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Documents] PRIMARY KEY CLUSTERED 
(
	[docid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExaminationQuestions]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationQuestions](
	[ExamId] [int] NOT NULL,
	[QuestionId] [int] NOT NULL,
	[OrderNo] [int] NULL,
 CONSTRAINT [PK_ExaminationQuestions] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExaminationQuestionsActives]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExaminationQuestionsActives](
	[ExamId] [int] NULL,
	[QuestionId] [int] NULL,
	[OrderNo] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[QuestionType] [int] NULL,
	[Score] [float] NULL,
	[IsRandom] [bit] NULL,
	[IsGroupQuestion] [bit] NULL,
	[ParentQuestionId] [bit] NULL,
	[QuestionGuid] [uniqueidentifier] NULL,
	[ExaminationQuestionsActiveId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_ExaminationQuestionsActives] PRIMARY KEY CLUSTERED 
(
	[ExaminationQuestionsActiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Examinations]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Examinations](
	[ExamId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[ExamType] [int] NULL,
	[MaxScore] [float] NULL,
	[PassScore] [float] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[TotalQuestion] [int] NULL,
	[IsActive] [bit] NULL,
	[TotalTime] [int] NULL,
	[ContentProviderId] [int] NULL,
	[UserMarkStringList] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_Examinations] PRIMARY KEY CLUSTERED 
(
	[ExamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groups]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groups](
	[groupid] [int] IDENTITY(1,1) NOT NULL,
	[groupname] [nvarchar](max) NULL,
	[isdeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED 
(
	[groupid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Groupuser]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Groupuser](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[groupid] [int] NOT NULL,
	[userid] [int] NOT NULL,
	[isleader] [bit] NULL,
 CONSTRAINT [PK_Groupuser] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Interview]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interview](
	[interviewid] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[deparmentid] [int] NULL,
	[time] [datetime2](7) NULL,
 CONSTRAINT [PK_Interview] PRIMARY KEY CLUSTERED 
(
	[interviewid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notification]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notification](
	[notiid] [int] IDENTITY(1,1) NOT NULL,
	[notitype] [nvarchar](50) NULL,
	[notiuserid] [int] NULL,
	[notiread] [int] NULL,
	[noticreate] [nvarchar](50) NULL,
	[notiupdate] [nvarchar](50) NULL,
	[notifromid] [int] NULL,
 CONSTRAINT [PK_Notification] PRIMARY KEY CLUSTERED 
(
	[notiid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Partner]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Partner](
	[partnerid] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](max) NULL,
	[fileurl] [nvarchar](max) NULL,
	[time] [datetime2](7) NOT NULL,
	[status] [int] NOT NULL,
	[departmentpartnerid] [int] NOT NULL,
	[phone] [nvarchar](50) NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Partner] PRIMARY KEY CLUSTERED 
(
	[partnerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Privatemessage]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Privatemessage](
	[messageid] [int] IDENTITY(1,1) NOT NULL,
	[messagetitle] [nvarchar](255) NULL,
	[messagesenderid] [int] NULL,
	[messagereceiveid] [int] NULL,
	[messagecontent] [text] NULL,
	[messagecreateat] [nvarchar](255) NULL,
	[messageupdateat] [nvarchar](255) NULL,
	[messageread] [int] NULL,
 CONSTRAINT [PK_PrivateMessage] PRIMARY KEY CLUSTERED 
(
	[messageid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projectgroups]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projectgroups](
	[projectid] [int] NOT NULL,
	[groupid] [int] NULL,
 CONSTRAINT [PK_Projectgroup] PRIMARY KEY CLUSTERED 
(
	[projectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projects](
	[projectid] [int] IDENTITY(1,1) NOT NULL,
	[projectname] [nvarchar](max) NULL,
	[endplan] [datetime2](7) NOT NULL,
	[startactual] [datetime2](7) NULL,
	[startplan] [datetime2](7) NOT NULL,
	[endactual] [datetime2](7) NULL,
	[leaderid] [int] NULL,
	[docid] [int] NULL,
	[note] [varchar](max) NULL,
	[status] [int] NULL,
	[projectcode] [varchar](50) NULL,
	[require] [varchar](max) NULL,
 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[projectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Questions]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Questions](
	[QuestionId] [int] IDENTITY(1,1) NOT NULL,
	[Content] [nvarchar](max) NULL,
	[QuestionType] [int] NULL,
	[Score] [float] NULL,
	[IsRandom] [bit] NULL,
	[IsActive] [bit] NULL,
	[CreatedBy] [int] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[ModifiedBy] [int] NULL,
	[ModifiedAt] [datetime2](7) NULL,
	[IsGroupQuestion] [bit] NULL,
	[OrderNo] [int] NULL,
	[ParentQuestionId] [int] NULL,
	[QuestionGuid] [uniqueidentifier] NULL,
	[ContentProviderId] [int] NULL,
 CONSTRAINT [PK_Questions] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[QuestionsActices]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QuestionsActices](
	[ExamId] [int] NULL,
	[QuestionId] [int] NULL,
	[OrderNo] [int] NULL,
	[Content] [nvarchar](max) NULL,
	[QuestionType] [int] NULL,
	[Score] [float] NULL,
	[IsRandom] [bit] NULL,
	[IsGroupQuestion] [bit] NULL,
	[ParentQuestionId] [int] NULL,
	[QuestionGuid] [uniqueidentifier] NULL,
	[ExaminationQuestionsActiveId] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_QuestionsActices] PRIMARY KEY CLUSTERED 
(
	[ExaminationQuestionsActiveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[requestid] [int] IDENTITY(1,1) NOT NULL,
	[requestname] [nvarchar](max) NULL,
	[content] [nvarchar](max) NULL,
	[userid] [int] NOT NULL,
	[receiverid] [int] NOT NULL,
	[sentdate] [datetime2](7) NOT NULL,
	[moretime] [datetime2](7) NULL,
	[status] [int] NOT NULL,
	[responecontent] [nvarchar](max) NULL,
	[reply] [bit] NULL,
	[taskid] [int] NULL,
	[requestmoney] [decimal](18, 2) NULL,
	[totaltime] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[requestid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tests]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tests](
	[testcode] [nvarchar](50) NOT NULL,
	[testname] [nvarchar](50) NULL,
	[totalmark] [int] NULL,
	[averagemark] [int] NULL,
 CONSTRAINT [PK_Test] PRIMARY KEY CLUSTERED 
(
	[testcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[userid] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](max) NULL,
	[isemployee] [bit] NOT NULL,
	[islead] [bit] NOT NULL,
	[email] [nvarchar](max) NULL,
	[phone] [nvarchar](max) NULL,
	[password] [nvarchar](max) NULL,
	[avatar] [nvarchar](max) NULL,
	[isdeleted] [bit] NOT NULL,
	[isfreelancer] [bit] NULL,
	[gender] [bit] NULL,
	[address] [nvarchar](max) NULL,
	[birthday] [datetime2](7) NULL,
	[cmndbefore] [nvarchar](max) NULL,
	[cmndafter] [nvarchar](max) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExaminationAnswers]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExaminationAnswers](
	[UserExaminationAnswerId] [int] IDENTITY(1,1) NOT NULL,
	[UserExaminationId] [int] NULL,
	[QuestionId] [int] NULL,
	[AnswerContent] [nvarchar](max) NULL,
	[IsRightAnswer] [bit] NULL,
	[IsEssayAnswer] [bit] NULL,
	[Score] [float] NULL,
	[ExaminationQuestionsActiveId] [int] NULL,
 CONSTRAINT [PK_ExaminationAnswers] PRIMARY KEY CLUSTERED 
(
	[UserExaminationAnswerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExaminations]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserExaminations](
	[UserExaminationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ExamId] [int] NULL,
	[StatusEnumValue] [int] NULL,
	[Score] [float] NULL,
	[CreatedAt] [datetime2](7) NULL,
	[TimeConsumed] [int] NULL,
	[ResultEnumValue] [int] NULL,
	[UserExaminationGuid] [uniqueidentifier] NULL,
	[UserMarkStringList] [nvarchar](max) NULL,
	[UserMarkedId] [int] NULL,
	[ContentProviderId] [int] NULL,
	[partnerid] [int] NULL,
 CONSTRAINT [PK_UserExaminations] PRIMARY KEY CLUSTERED 
(
	[UserExaminationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userrole]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userrole](
	[userroleid] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](max) NULL,
	[displayname] [nvarchar](max) NULL,
	[isprivate] [bit] NOT NULL,
 CONSTRAINT [PK_Userrole] PRIMARY KEY CLUSTERED 
(
	[userroleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Useruserrole]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Useruserrole](
	[userid] [int] NOT NULL,
	[userroleid] [int] NOT NULL,
 CONSTRAINT [PK_Useruserrole] PRIMARY KEY CLUSTERED 
(
	[userid] ASC,
	[userroleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zoom]    Script Date: 7/25/2021 8:52:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zoom](
	[zoomid] [int] IDENTITY(1,1) NOT NULL,
	[zoomtitle] [nvarchar](255) NULL,
	[zoomcode] [text] NULL,
	[zoomstarturl] [nvarchar](max) NULL,
	[zoomhost] [int] NULL,
	[zoomjoinurl] [nvarchar](max) NULL,
	[zoomagenda] [nvarchar](255) NULL,
	[zoomstarttime] [nvarchar](255) NULL,
	[zoompass] [nvarchar](255) NULL,
	[zoomteam] [int] NULL,
	[zoommember] [int] NULL,
	[zoomcreateat] [nvarchar](50) NULL,
	[zoomupdateat] [nvarchar](50) NULL,
 CONSTRAINT [PK_Zoom] PRIMARY KEY CLUSTERED 
(
	[zoomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Affairs] ON 

INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (1, N'Analyze Document', 0, CAST(N'2021-09-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-02T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (2, N'Analize Database ', 0, CAST(N'2021-09-03T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-06T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (3, N'Analyze Module', 0, CAST(N'2021-09-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-09T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (4, N'Analyze Requirement', 0, CAST(N'2021-09-10T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-13T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (5, N'Analyze Technology', 0, CAST(N'2021-09-14T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-16T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (6, N'Design Login', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-17T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (7, N'Design Index Page', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-22T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (8, N'Design Project page', 0, CAST(N'2021-09-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-23T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (9, N'Design Affair page', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-20T15:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (10, N'Design User Page', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-17T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (11, N'Design Cost page', 0, CAST(N'2021-09-20T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-21T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (12, N'Design Calender page', 0, CAST(N'2021-09-21T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-23T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (13, N'Design Chat page', 0, CAST(N'2021-09-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-24T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (14, N'Design Request page', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-23T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (15, N'Design Interview Page', 0, CAST(N'2021-09-20T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-27T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (16, N'Design Recruitment', 0, CAST(N'2021-09-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-21T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (17, N'Implement Login Page', 0, CAST(N'2021-09-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-24T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (18, N'Implement Index Page', 0, CAST(N'2021-09-21T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-24T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (19, N'Implement Project page', 0, CAST(N'2021-09-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-30T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (20, N'Implement Affair page', 0, CAST(N'2021-09-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-28T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (21, N'Implement User page ', 0, CAST(N'2021-09-27T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-29T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (22, N'Implement Cost page', 0, CAST(N'2021-09-29T13:00:00.0000000' AS DateTime2), CAST(N'2021-10-06T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (23, N'Implement Calander page', 0, CAST(N'2021-09-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (24, N'Implement Request page', 0, CAST(N'2021-09-27T09:00:00.0000000' AS DateTime2), CAST(N'2021-09-30T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (25, N'Implement Interview Page', 0, CAST(N'2021-10-04T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (26, N'Implement Recruitment Page', 0, CAST(N'2021-09-24T13:00:00.0000000' AS DateTime2), CAST(N'2021-09-29T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (27, N'Test Login Page', 0, CAST(N'2021-10-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-01T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (28, N'Test Index Page', 0, CAST(N'2021-10-04T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-04T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (29, N'Test Project page', 0, CAST(N'2021-09-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-01T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (31, N'Test Affair page', 0, CAST(N'2021-10-08T13:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (32, N'Test user page', 0, CAST(N'2021-10-04T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-05T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (33, N'Test Cost page', 0, CAST(N'2021-10-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (34, N'Test Calender', 0, CAST(N'2021-09-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-01T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (35, N'Test Cost page', 0, CAST(N'2021-10-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-14T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 14, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (36, N'Test Interview page', 0, CAST(N'2021-10-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (37, N'Test Recruitment page', 0, CAST(N'2021-10-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-15T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (38, N'Deploy Login', 0, CAST(N'2021-10-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (39, N'Deploy Index', 0, CAST(N'2021-10-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-13T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (40, N'Deploy Project', 0, CAST(N'2021-10-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-08T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (41, N'Deploy Affair', 0, CAST(N'2021-10-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-14T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 9, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (42, N'Deploy User', 0, CAST(N'2021-10-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-13T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 6, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (43, N'Deploy Cost page', 0, CAST(N'2021-10-18T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-20T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 4, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (44, N'Deploy Calender', 0, CAST(N'2021-10-04T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-07T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (45, N'Deploy Interview page', 0, CAST(N'2021-10-14T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-15T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 3, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (46, N'Deploy Recruitment', 0, CAST(N'2021-10-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-10-12T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 7, NULL, NULL, 1, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (47, N'Analize Document', 2, CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-04T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-04T12:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (48, N'Analyze Database ', 3, CAST(N'2021-06-04T13:00:00.0000000' AS DateTime2), CAST(N'2021-06-08T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-04T13:00:00.0000000' AS DateTime2), CAST(N'2021-06-08T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (49, N'Analyze Module', 2, CAST(N'2021-06-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (50, N'Analyze Requirement', 4, CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-07T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-07T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (51, N'Analyze Difficulties', 2, CAST(N'2021-06-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-10T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-10T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (52, N'Analyze Technology', 2, CAST(N'2021-06-14T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-14T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (53, N'Design Login', 2, CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-14T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-14T12:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (54, N'Design Index Page', 4, CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (55, N'Design Index Android', 4, CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (56, N'Design Detail Page', 3, CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-15T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-15T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (57, N'Design Detail Android', 2, CAST(N'2021-06-15T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-18T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-15T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-18T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (58, N'Design Upload Page', 0, CAST(N'2021-06-16T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-16T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (59, N'Design Upload Android', 2, CAST(N'2021-06-18T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-18T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (60, N'Design Chat page', 2, CAST(N'2021-06-21T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-23T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-23T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (61, N'Design Chat Android', 3, CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (62, N'Design User Page', 3, CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-21T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (63, N'Design User Android', 4, CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (64, N'Design Personal page', 2, CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (65, N'Design Search Page + Android', 1, CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T12:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (66, N'Implement Login Page', 0, CAST(N'2021-06-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (67, N'Implement Index Page', 2, CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (68, N'Implement Index Android', 0, CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (69, N'Implement Detail page', 0, CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (70, N'Implement Detail Android', 0, CAST(N'2021-06-25T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-25T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (71, N'Implement Chat Page', 0, CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (72, N'Implement Chat Android', 0, CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (73, N'Implament Upload Android', 0, CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (74, N'Implement Upload Android', 0, CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (75, N'Implement User page ', 0, CAST(N'2021-06-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (76, N'Implement User Android', 2, CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-22T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (77, N'Implement Personal page', 1, CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (78, N'Implement Search Page + Android', 2, CAST(N'2021-06-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (79, N'Test Login Page', 0, CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (80, N'Test Index Page', 1, CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T12:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (81, N'Test Index Android', 20, CAST(N'2021-06-30T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (82, N'Test Detail Page', 0, CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T15:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (83, N'Test Chat Page +Android', 3, CAST(N'2021-06-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-24T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-28T12:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (84, N'Test Upload Page + Android', 2, CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (85, N'Test User Page + Android', 2, CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (86, N'Test Personal Page', 2, CAST(N'2021-07-02T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (87, N'Test Search Page + Android', 1, CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T18:00:00.0000000' AS DateTime2), CAST(N'2021-06-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-30T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (88, N'Deploy Login', 2, CAST(N'2021-07-02T10:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T10:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (89, N'Deploy Index Page + Android', 4, CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (90, N'Deploy Detail', 1, CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (91, N'Deploy Chat Page + Android', 2, CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (92, N'Deploy Upload', 2, CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (93, N'Deploy User Page + Android', 1, CAST(N'2021-07-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T12:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (94, N'Deploy Personal Page', 1, CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (95, N'Deploy Search Page + Android', 2, CAST(N'2021-07-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T18:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 2, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (96, N'Analyze Document', 1, CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T16:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-02T16:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (97, N'Analyze Database ', 1, CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (98, N'Analyze Module', 1, CAST(N'2021-07-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T12:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (99, N'Analyze Requirement', 3, CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-05T12:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (100, N'Analyze Technology', 0, CAST(N'2021-07-08T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 0)
GO
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (101, N'Analyze Difficulties', 1, CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-07T12:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (102, N'Analyze UI', 0, CAST(N'2021-07-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-09T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 0)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (103, N'Design Login', 0, CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T14:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T14:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (104, N'Design Database', 3, CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T15:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (105, N'Design Index Page', 3, CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T15:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (106, N'Design User Page', 3, CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (107, N'Design Enrollment  page', 2, CAST(N'2021-07-08T14:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-08T14:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T12:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (108, N'Design Testing Page', 3, CAST(N'2021-07-12T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-12T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (109, N'Design Attendance page', 2, CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), 4, 10, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (110, N'Design Feedback page', 2, CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (111, N'Design Personal page', 1, CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-15T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-15T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (112, N'Design Grade page', 2, CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T18:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (113, N'Design Timetable page', 2, CAST(N'2021-07-16T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T18:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 3, 1)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (114, N'Implement Login Page', 0, CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-16T18:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (115, N'Implement Index Page', 2, CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-22T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-22T12:00:00.0000000' AS DateTime2), 4, 13, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (116, N'Implement User page ', 1, CAST(N'2021-07-20T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-22T15:00:00.0000000' AS DateTime2), CAST(N'2021-07-20T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-22T15:00:00.0000000' AS DateTime2), 4, 12, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (117, N'Implement Enrollment page', 3, CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T12:00:00.0000000' AS DateTime2), 4, 11, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (118, N'Implement Test Page', 3, CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T12:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (119, N'Implement Attendance', 6, CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-28T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-19T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-28T18:00:00.0000000' AS DateTime2), 3, 10, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (120, N'Implement Feedback page', 4, CAST(N'2021-07-23T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T13:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), 3, 11, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (121, N'Implement Personal page', 3, CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-27T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-27T12:00:00.0000000' AS DateTime2), 3, 12, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (122, N'Implement Grade page', 4, CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), 3, 13, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (123, N'Implement Timetable page', 1, CAST(N'2021-07-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-28T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T12:00:00.0000000' AS DateTime2), 1, 12, NULL, NULL, 3, 2)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (124, N'Test Login Page', 0, CAST(N'2021-07-29T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-29T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 10, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (125, N'Test Index Page', 1, CAST(N'2021-08-02T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-04T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 13, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (126, N'Test User page', 2, CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-26T18:00:00.0000000' AS DateTime2), CAST(N'2021-07-23T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-26T18:00:00.0000000' AS DateTime2), 4, 2, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (127, N'Test Enrollment page', 3, CAST(N'2021-07-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-04T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-04T12:00:00.0000000' AS DateTime2), 1, 10, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (128, N'Test Testing Page', 3, CAST(N'2021-08-02T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-06T13:00:00.0000000' AS DateTime2), NULL, NULL, 0, 12, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (129, N'Test Attendance page', 6, CAST(N'2021-07-27T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-06T12:00:00.0000000' AS DateTime2), CAST(N'2021-07-27T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-06T12:00:00.0000000' AS DateTime2), 2, 2, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (130, N'Test Feedback page', 1, CAST(N'2021-08-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-06T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 10, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (131, N'Test Personal Page', 2, CAST(N'2021-08-02T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-05T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 11, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (132, N'Test Grade page', 2, CAST(N'2021-08-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 2, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (133, N'Test Time table page', 3, CAST(N'2021-08-05T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-10T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 13, NULL, NULL, 3, 3)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (134, N'Deploy Login', 0, CAST(N'2021-08-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-09T18:00:00.0000000' AS DateTime2), NULL, NULL, 0, 10, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (135, N'Deploy Index', 1, CAST(N'2021-08-11T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-13T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 13, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (136, N'Deploy User', 2, CAST(N'2021-08-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-16T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 2, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (137, N'Deploy Enrollment page', 1, CAST(N'2021-08-10T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T11:00:00.0000000' AS DateTime2), NULL, NULL, 0, 10, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (138, N'Deploy Testing Page', 2, CAST(N'2021-08-09T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-12T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 12, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (139, N'Deploy Attendance page', 1, CAST(N'2021-08-17T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-19T15:00:00.0000000' AS DateTime2), NULL, NULL, 0, 2, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (140, N'Deploy Feedback page', 3, CAST(N'2021-08-13T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-18T11:00:00.0000000' AS DateTime2), NULL, NULL, 0, 10, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (141, N'Deploy Personal Page', 3, CAST(N'2021-08-06T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-10T14:00:00.0000000' AS DateTime2), NULL, NULL, 0, 11, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (142, N'Deploy Grade page', 3, CAST(N'2021-08-20T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-25T16:00:00.0000000' AS DateTime2), NULL, NULL, 0, 2, NULL, NULL, 3, 4)
INSERT [dbo].[Affairs] ([affairid], [affairname], [affairtag], [starttimeplan], [endtimeplan], [starttimeactual], [endtimeactual], [status], [userid], [notemember], [noteleader], [projectid], [typeofaffair]) VALUES (143, N'Deploy Timetable page', 2, CAST(N'2021-08-16T09:00:00.0000000' AS DateTime2), CAST(N'2021-08-19T12:00:00.0000000' AS DateTime2), NULL, NULL, 0, 13, NULL, NULL, 3, 4)
SET IDENTITY_INSERT [dbo].[Affairs] OFF
GO
SET IDENTITY_INSERT [dbo].[AnswerActives] ON 

INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, 1, N'Nó được khai báo bên trong các hàm hoặc thủ tục, kể cả hàm main ().', 1, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1307383' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (2, 1, N'Nó đươc khai báo bên trong các hàm ngoại trừ hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1341054' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (3, 1, N'Nó được khai báo bên trong hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1355177' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (4, 1, N'Nó được khai báo bên ngoài các hàm kể cả hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1370839' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (5, 2, N'Miền nhớ giành cho x không bị thay đổi trong quá trình thực hiện chương trình.', 1, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5837111' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (6, 2, N'Miền nhớ dành cho x sẽ thay đổi bởi những thao tác với x trong tất cả các hàm, kể cả hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5826369' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (7, 2, N'Miền nhớ dành cho x chỉ có thay đổi bởi những thao tác với x bên trong hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5814958' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (8, 2, N'Miền nhớ dành cho x có thể thay đổi trong quá trình thực hiện chương trình.', 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5799740' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (9, 3, N'1976', 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8508065' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (10, 3, N'1970', 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8492915' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (11, 3, N'1972', 1, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8458573' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (12, 3, N'1967', 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8426575' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (13, 4, N'(a&=b).', 1, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2151965' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (14, 4, N'(a=b).', 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2137152' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (15, 4, N' (a*=b).', 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2082993' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (16, 4, N' (a+=b).', 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2033164' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (17, 5, N'Nó được khai báo bên trong hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0270999' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (18, 5, N'Nó được khai báo bên ngoài hàm main ().', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0259965' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (19, 5, N'Nó được khai báo ngoài tất cả các hàm kể cả hàm main ().', 1, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0243980' AS DateTime2), NULL, NULL)
INSERT [dbo].[AnswerActives] ([AnswerId], [ExaminationQuestionsActiveId], [Content], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (20, 5, N'Nó được khai báo tất cả các hàm, ngoại trừ hàm main ()', 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0194028' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[AnswerActives] OFF
GO
SET IDENTITY_INSERT [dbo].[Answers] ON 

INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (1, N'Ngôn ngữ B', 1, 0, 0, 0, NULL, CAST(N'2021-07-23T16:17:15.1310489' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (2, N'Ngôn ngữ BCPL', 1, 0, 0, 0, NULL, CAST(N'2021-07-23T16:17:15.1535272' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (3, N'Ngôn ngữ DEC PDP', 1, 0, 0, 0, NULL, CAST(N'2021-07-23T16:17:15.1558524' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (4, N'Ngôn ngữ B và BCPL', 1, 1, 0, 0, NULL, CAST(N'2021-07-23T16:17:15.1595904' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (5, N'1967', 2, 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8426575' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (6, N'1972', 2, 1, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8458573' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (7, N'1970', 2, 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8492915' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (8, N'1976', 2, 0, 0, 0, NULL, CAST(N'2021-07-23T16:18:47.8508065' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (9, N'Ngôn ngữ Assembler', 3, 0, 0, 0, NULL, CAST(N'2021-07-23T16:19:29.1941184' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (10, N'Ngôn ngữ C và Pascal.', 3, 1, 0, 0, NULL, CAST(N'2021-07-23T16:19:29.1957466' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (11, N'Ngôn ngữ Cobol.', 3, 0, 0, 0, NULL, CAST(N'2021-07-23T16:19:29.1968905' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (12, N'a, b và c', 3, 0, 0, 0, NULL, CAST(N'2021-07-23T16:19:29.1983389' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (13, N'diem toan', 4, 0, 0, 0, NULL, CAST(N'2021-07-23T16:20:19.7646598' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (14, N'3diemtoan', 4, 0, 0, 0, NULL, CAST(N'2021-07-23T16:20:19.7674486' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (15, N'_diemtoan', 4, 1, 0, 0, NULL, CAST(N'2021-07-23T16:20:19.7688634' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (16, N'-diemtoan', 4, 0, 0, 0, NULL, CAST(N'2021-07-23T16:20:19.7699217' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (17, N'Nó được khai báo tất cả các hàm, ngoại trừ hàm main ()', 5, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0194028' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (18, N'Nó được khai báo ngoài tất cả các hàm kể cả hàm main ().', 5, 1, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0243980' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (19, N'Nó được khai báo bên ngoài hàm main ().', 5, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0259965' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (20, N'Nó được khai báo bên trong hàm main ().', 5, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:07.0270999' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (21, N'Nó được khai báo bên trong các hàm hoặc thủ tục, kể cả hàm main ().', 6, 1, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1307383' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (22, N'Nó đươc khai báo bên trong các hàm ngoại trừ hàm main ().', 6, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1341054' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (23, N'Nó được khai báo bên trong hàm main ().', 6, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1355177' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (24, N'Nó được khai báo bên ngoài các hàm kể cả hàm main ().', 6, 0, 0, 0, NULL, CAST(N'2021-07-23T16:21:50.1370839' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (25, N'Miền nhớ dành cho x có thể thay đổi trong quá trình thực hiện chương trình.', 7, 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5799740' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (26, N'Miền nhớ dành cho x chỉ có thay đổi bởi những thao tác với x bên trong hàm main ().', 7, 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5814958' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (27, N'Miền nhớ dành cho x sẽ thay đổi bởi những thao tác với x trong tất cả các hàm, kể cả hàm main ().', 7, 0, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5826369' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (28, N'Miền nhớ giành cho x không bị thay đổi trong quá trình thực hiện chương trình.', 7, 1, 0, 0, NULL, CAST(N'2021-07-23T16:22:31.5837111' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (29, N'Kiểu double.', 8, 1, 0, 0, NULL, CAST(N'2021-07-23T16:23:20.9167005' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (30, N'Kiểu con trỏ.', 8, 0, 0, 0, NULL, CAST(N'2021-07-23T16:23:20.9195146' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (31, N'Kiểu hợp.', 8, 0, 0, 0, NULL, CAST(N'2021-07-23T16:23:20.9229030' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (32, N'Kiểu mảng.', 8, 0, 0, 0, NULL, CAST(N'2021-07-23T16:23:20.9241831' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (33, N' (a+=b).', 9, 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2033164' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (34, N' (a*=b).', 9, 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2082993' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (35, N'(a=b).', 9, 0, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2137152' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (36, N'(a&=b).', 9, 1, 0, 0, NULL, CAST(N'2021-07-23T16:24:09.2151965' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (37, N'(ab).', 10, 0, 0, 0, NULL, CAST(N'2021-07-23T16:25:05.7339024' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (38, N'(a-=b).', 10, 0, 0, 0, NULL, CAST(N'2021-07-23T16:25:05.7361636' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (39, N'(a*=b).', 10, 0, 0, 0, NULL, CAST(N'2021-07-23T16:25:05.7377861' AS DateTime2), NULL, NULL)
INSERT [dbo].[Answers] ([AnswerId], [Content], [QuestionId], [IsCorrect], [IsMultipleAnswer], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt]) VALUES (40, N'(a>>=b).', 10, 1, 0, 0, NULL, CAST(N'2021-07-23T16:25:05.7742048' AS DateTime2), NULL, NULL)
SET IDENTITY_INSERT [dbo].[Answers] OFF
GO
SET IDENTITY_INSERT [dbo].[Authapplication] ON 

INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (1, N'ProjectManagement', N'ProjectManagement')
INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (2, N'User', N'User')
INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (3, N'KOPC', N'KOPC')
INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (4, N'Module4', N'Module4')
INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (5, N'Backup', N'Backup')
INSERT [dbo].[Authapplication] ([authapplicationid], [name], [displayname]) VALUES (6, N'Group', N'Group')
SET IDENTITY_INSERT [dbo].[Authapplication] OFF
GO
SET IDENTITY_INSERT [dbo].[Authcontroller] ON 

INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (2, N'Project', N'Projects', N'fas fa-file', 1)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (3, N'Document', N'Documents', N'fas fa-file', 1)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (4, N'Costsalary', N'Cost', N'fas fa-dollar-sign', 3)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (5, N'Requestpm', N'Requests', N'fas fa-envelope', 3)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (6, N'User', N'Users', N'fas fa-users', 2)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (7, N'Group', N'Groups', N'fas fa-user-friends', 6)
INSERT [dbo].[Authcontroller] ([authcontrollerid], [name], [display], [iconclass], [authapplicationid]) VALUES (8, N'Backup', N'Backup Database', N'fas fa-calculator', 5)
SET IDENTITY_INSERT [dbo].[Authcontroller] OFF
GO
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (1, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (1, 2)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (1, 3)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (1, 4)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (1, 6)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (2, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (2, 2)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (2, 3)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (2, 4)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (2, 6)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (3, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (3, 6)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (4, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (4, 2)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (4, 3)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (4, 4)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (4, 6)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (5, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (5, 6)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (6, 1)
INSERT [dbo].[Authuser] ([authappliactionid], [userid]) VALUES (6, 6)
GO
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (1, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (1, 2)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (2, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (2, 2)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (3, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (3, 2)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (4, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (4, 2)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (4, 3)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (4, 4)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (5, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (5, 2)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (6, 1)
INSERT [dbo].[Authuserrole] ([authapplicationid], [userroleid]) VALUES (6, 2)
GO
SET IDENTITY_INSERT [dbo].[Chatroom] ON 

INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (1, 2, N'xin chào', 2, N'21-Jul-21 8:55:50 AM', N'21-Jul-21 8:55:50 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (2, 2, N'xin chào', 2, N'21-Jul-21 8:55:50 AM', N'21-Jul-21 8:55:50 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (3, 6, N'hello', 2, N'21-Jul-21 8:56:03 AM', N'21-Jul-21 8:56:03 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (4, 6, N'how r u today ?', 2, N'21-Jul-21 8:59:35 AM', N'21-Jul-21 8:59:35 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (5, 6, N'What is about Test ?', 2, N'21-Jul-21 9:02:27 AM', N'21-Jul-21 9:02:27 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (6, 2, N'So easy', 2, N'21-Jul-21 9:03:45 AM', N'21-Jul-21 9:03:45 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (7, 2, N'Sorry im lost message', 2, N'21-Jul-21 9:07:38 AM', N'21-Jul-21 9:07:38 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (8, 6, N'It''s OK, dont worry about that', 2, N'21-Jul-21 9:12:57 AM', N'21-Jul-21 9:12:57 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (9, 2, N'báo cáo 21/07: hoàn thành màn hình 47. Khó khăn chưa có.', 2, N'21-Jul-21 10:59:19 AM', N'21-Jul-21 10:59:19 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (10, 6, N'test', 2, N'21-Jul-21 10:59:54 AM', N'21-Jul-21 10:59:54 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (11, 2, N'test', 2, N'21-Jul-21 11:01:20 AM', N'21-Jul-21 11:01:20 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (12, 2, N'finish
', 2, N'21-Jul-21 11:01:43 AM', N'21-Jul-21 11:01:43 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (13, 6, N'het lỗi rồi
', 2, N'21-Jul-21 11:01:53 AM', N'21-Jul-21 11:01:53 AM')
INSERT [dbo].[Chatroom] ([chatroomid], [chatuserid], [chatusercontent], [chatusergroup], [chatusercreateat], [chatuserupdateat]) VALUES (14, 2, N'ok', 2, N'21-Jul-21 11:02:04 AM', N'21-Jul-21 11:02:04 AM')
SET IDENTITY_INSERT [dbo].[Chatroom] OFF
GO
SET IDENTITY_INSERT [dbo].[Departmentpartner] ON 

INSERT [dbo].[Departmentpartner] ([departmentpartnerid], [title], [desc], [duration], [timeend], [department], [img], [status], [shortdesc], [examid], [quantity]) VALUES (1, N'TELECOMMUNICATION JOINT STOCK', N'<p style="color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Capability Requirements:</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Bachelor''s degree in computer science/software engineering or related fields.</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Experience in .NET framework (C#)</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Experience in Winforms</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Knowledge of Database and SQL Web API Good design knowledge</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Good communication skill</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Creativity, flexibility in solving problems, .., expanding solutions</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Priority: Energetic and eager to learn about the field of LOT</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Responsible and high work spirit</font></p>', 0, CAST(N'2021-07-31T00:00:00.0000000' AS DateTime2), 0, N'/Partner/anhtuyendung.jpg', 0, N'<p style="color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Participating in the development of Windows software systems based on the .NET framework (C#) for the field of digitizing production systems.</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">In-depth training in industrial communication and ERP</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Working in District 1, good policy regime, insurance, annual vacation, Tet bonus, periodical health check.</font></p><p style="margin-top: 10px; color: rgb(93, 103, 122); font-family: Roboto, sans-serif; font-size: 16px;"><font style="vertical-align: inherit;">Details will be discussed in the interview.</font></p>', 1, 5)
SET IDENTITY_INSERT [dbo].[Departmentpartner] OFF
GO
SET IDENTITY_INSERT [dbo].[Documents] ON 

INSERT [dbo].[Documents] ([docid], [title], [authorrole], [authorname], [files], [note]) VALUES (2, N'title of document', 6, N'Bùi Bá Hưng', N'/Doc/Tài liệu không có tiêu đề.pdf', N'<p>prj 4</p>')
SET IDENTITY_INSERT [dbo].[Documents] OFF
GO
SET IDENTITY_INSERT [dbo].[ExaminationQuestionsActives] ON 

INSERT [dbo].[ExaminationQuestionsActives] ([ExamId], [QuestionId], [OrderNo], [Content], [QuestionType], [Score], [IsRandom], [IsGroupQuestion], [ParentQuestionId], [QuestionGuid], [ExaminationQuestionsActiveId]) VALUES (1, 6, 1, N'Một biến được gọi là một biến địa phương nếu', 1, 2, 1, 0, NULL, N'6572e298-ddb8-4fae-9f7a-f94736842778', 1)
INSERT [dbo].[ExaminationQuestionsActives] ([ExamId], [QuestionId], [OrderNo], [Content], [QuestionType], [Score], [IsRandom], [IsGroupQuestion], [ParentQuestionId], [QuestionGuid], [ExaminationQuestionsActiveId]) VALUES (1, 7, 2, N'Nếu x là một biến toàn cục và x không phải là một con trỏ thì:', 1, 2, 1, 0, NULL, N'aa70c9f2-64a9-4ff2-8bcc-1279d996bc76', 2)
INSERT [dbo].[ExaminationQuestionsActives] ([ExamId], [QuestionId], [OrderNo], [Content], [QuestionType], [Score], [IsRandom], [IsGroupQuestion], [ParentQuestionId], [QuestionGuid], [ExaminationQuestionsActiveId]) VALUES (1, 2, 3, N'Ngôn ngữ lập trình được Dennish đưa ra vào năm nào?', 1, 1, 1, 0, NULL, N'167180ca-85aa-4d69-a742-192fafc1356d', 3)
INSERT [dbo].[ExaminationQuestionsActives] ([ExamId], [QuestionId], [OrderNo], [Content], [QuestionType], [Score], [IsRandom], [IsGroupQuestion], [ParentQuestionId], [QuestionGuid], [ExaminationQuestionsActiveId]) VALUES (1, 9, 4, N'Giả sử a, b là hai số thực. Biểu thức nào dưới đây viết không đúng theo cú pháp của ngôn ngữ lập trình C:', 1, 1, 1, 0, NULL, N'b1efe3a2-a2f7-4709-9ef9-304944af81f8', 4)
INSERT [dbo].[ExaminationQuestionsActives] ([ExamId], [QuestionId], [OrderNo], [Content], [QuestionType], [Score], [IsRandom], [IsGroupQuestion], [ParentQuestionId], [QuestionGuid], [ExaminationQuestionsActiveId]) VALUES (1, 5, 5, N'Một biến được gọi là biến toàn cục nếu', 1, 1, 1, 0, NULL, N'a8d17861-352e-42b7-a8ce-d4dc1e79d26c', 5)
SET IDENTITY_INSERT [dbo].[ExaminationQuestionsActives] OFF
GO
SET IDENTITY_INSERT [dbo].[Examinations] ON 

INSERT [dbo].[Examinations] ([ExamId], [Name], [ExamType], [MaxScore], [PassScore], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [TotalQuestion], [IsActive], [TotalTime], [ContentProviderId], [UserMarkStringList], [IsDeleted], [UserId]) VALUES (1, N'C knowledge', 1, 7, 5, NULL, CAST(N'2021-07-23T16:25:55.5544322' AS DateTime2), NULL, NULL, 5, 1, 5, 1, NULL, 0, NULL)
SET IDENTITY_INSERT [dbo].[Examinations] OFF
GO
SET IDENTITY_INSERT [dbo].[Groups] ON 

INSERT [dbo].[Groups] ([groupid], [groupname], [isdeleted]) VALUES (1, N'SuperDev', 0)
INSERT [dbo].[Groups] ([groupid], [groupname], [isdeleted]) VALUES (2, N'SuperTester', 0)
INSERT [dbo].[Groups] ([groupid], [groupname], [isdeleted]) VALUES (3, NULL, 1)
SET IDENTITY_INSERT [dbo].[Groups] OFF
GO
SET IDENTITY_INSERT [dbo].[Groupuser] ON 

INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (1, 1, 6, 1)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (2, 1, 3, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (3, 1, 4, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (4, 2, 2, 1)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (5, 2, 10, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (6, 2, 11, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (7, 2, 12, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (8, 1, 7, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (9, 1, 9, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (10, 2, 13, 0)
INSERT [dbo].[Groupuser] ([id], [groupid], [userid], [isleader]) VALUES (11, 1, 14, 0)
SET IDENTITY_INSERT [dbo].[Groupuser] OFF
GO
SET IDENTITY_INSERT [dbo].[Notification] ON 

INSERT [dbo].[Notification] ([notiid], [notitype], [notiuserid], [notiread], [noticreate], [notiupdate], [notifromid]) VALUES (1, N'meeting', 2, 1, N'21-Jul-21 10:55:28 AM', N'21-Jul-21 10:55:28 AM', 2)
SET IDENTITY_INSERT [dbo].[Notification] OFF
GO
SET IDENTITY_INSERT [dbo].[Partner] ON 

INSERT [dbo].[Partner] ([partnerid], [email], [fileurl], [time], [status], [departmentpartnerid], [phone], [name]) VALUES (1, N'dungdilys@gmail.com', N'/Partner/demo.pdf', CAST(N'2021-07-24T15:39:45.1067401' AS DateTime2), 0, 1, N'0934995224', N'Ngô Thị Đoan Dung')
SET IDENTITY_INSERT [dbo].[Partner] OFF
GO
INSERT [dbo].[Projectgroups] ([projectid], [groupid]) VALUES (1, 1)
INSERT [dbo].[Projectgroups] ([projectid], [groupid]) VALUES (2, 2)
INSERT [dbo].[Projectgroups] ([projectid], [groupid]) VALUES (3, 2)
GO
SET IDENTITY_INSERT [dbo].[Projects] ON 

INSERT [dbo].[Projects] ([projectid], [projectname], [endplan], [startactual], [startplan], [endactual], [leaderid], [docid], [note], [status], [projectcode], [require]) VALUES (1, N'FourN', CAST(N'2021-10-30T09:00:00.0000000' AS DateTime2), NULL, CAST(N'2021-09-01T09:00:00.0000000' AS DateTime2), NULL, 6, NULL, NULL, 0, N'PRJCODE2021001', N'<p>C#</p><p>Springboot API</p><p>Android</p><p>SQLite</p><p>SQL Server</p>')
INSERT [dbo].[Projects] ([projectid], [projectname], [endplan], [startactual], [startplan], [endactual], [leaderid], [docid], [note], [status], [projectcode], [require]) VALUES (2, N'TikToker', CAST(N'2021-07-20T12:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-06-01T09:00:00.0000000' AS DateTime2), CAST(N'2021-07-30T18:00:00.0000000' AS DateTime2), 2, NULL, NULL, 6, N'PRJCODE2021010', N'<p>C#</p><p>MySQL</p><p>SQLite</p><p>Android</p><p>Springboot API</p>')
INSERT [dbo].[Projects] ([projectid], [projectname], [endplan], [startactual], [startplan], [endactual], [leaderid], [docid], [note], [status], [projectcode], [require]) VALUES (3, N'Student Management ', CAST(N'2021-08-30T12:00:00.0000000' AS DateTime2), NULL, CAST(N'2021-07-01T08:00:00.0000000' AS DateTime2), NULL, 2, NULL, NULL, 3, N'PRJCODE2021005', N'<p>PHP</p><p>MySQL</p><p>Springboot API</p><p>jQuery</p><p>AngularJS</p>')
SET IDENTITY_INSERT [dbo].[Projects] OFF
GO
SET IDENTITY_INSERT [dbo].[Questions] ON 

INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (1, N'Ngôn ngữ lập trình C được Dennish phát triển dựa trên ngôn ngữ lập trình nào', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:17:14.9557294' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (2, N'Ngôn ngữ lập trình được Dennish đưa ra vào năm nào?', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:18:47.8355046' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (3, N'Ngôn ngữ lập trình nào dưới đây là ngôn ngữ lập trình có cấu trúc', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:19:29.1805397' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (4, N'Những tên biến nào dưới đây được viết đúng theo quy tắc đặt tên của ngôn ngữ lập trình C?', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:20:19.7492163' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (5, N'Một biến được gọi là biến toàn cục nếu', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:21:07.0043203' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (6, N'Một biến được gọi là một biến địa phương nếu', 1, 2, 1, 1, 1, CAST(N'2021-07-23T16:21:50.1138145' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (7, N'Nếu x là một biến toàn cục và x không phải là một con trỏ thì:', 1, 2, 1, 1, 1, CAST(N'2021-07-23T16:22:31.5664293' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (8, N'Kiểu dữ liệu nào dưới đây được coi là kiểu dữ liệu cơ bản trong ngôn ngữ lập trình C:', 1, 3, 1, 1, 1, CAST(N'2021-07-23T16:23:20.9018433' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (9, N'Giả sử a, b là hai số thực. Biểu thức nào dưới đây viết không đúng theo cú pháp của ngôn ngữ lập trình C:', 1, 1, 1, 1, 1, CAST(N'2021-07-23T16:24:09.1874514' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
INSERT [dbo].[Questions] ([QuestionId], [Content], [QuestionType], [Score], [IsRandom], [IsActive], [CreatedBy], [CreatedAt], [ModifiedBy], [ModifiedAt], [IsGroupQuestion], [OrderNo], [ParentQuestionId], [QuestionGuid], [ContentProviderId]) VALUES (10, N'Giả sử a và b là hai số thực. Biểu thức nào dưới đây là không được phép theo cú pháp của ngôn ngữ lập trình C:', 1, 5, 1, 1, 1, CAST(N'2021-07-23T16:25:05.7193069' AS DateTime2), NULL, NULL, 0, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Questions] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (1, N'PM', 0, 0, N'buibavuong123456@gmail.com', N'0123456789', N'123', N'/img/User/demobook4.jfif', 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2000-07-23T05:00:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (2, N'Ngô Thị Đoan Dung', 0, 0, N'dungdilys@gmail.com', N'0394730844', N'123', N'/img/User/demobook6.jfif', 0, 0, 0, N'590 CMT8 TPHCM', CAST(N'2000-07-23T05:00:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (3, N'Vũ Mạnh Kiên', 1, 0, N'kinkin@gmail.com', N'0896745231', N'123', NULL, 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (4, N'Vũ Văn Chung', 1, 0, N'vuchung249@gmail.com', N'0789456123', N'123', NULL, 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (6, N'Bùi Bá Hưng', 0, 1, N'bubugihu@gmail.com', N'0678923451', N'123', NULL, 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (7, N'Ngô Nguyễn Trúc Phi', 1, 0, N'mail@gmail.com', N'0987346271', N'123', NULL, 0, 0, 0, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (9, N'Trần Ngọc Nguyên', 1, 0, N'Mailnguyen@gmail.com', N'0756567565', N'123', NULL, 0, 0, 0, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (10, N'Trần Kim Tú', 1, 0, N'mailtunguyen@gmail.com', N'0345247742', N'123', NULL, 0, 0, 0, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (11, N'Trần Khúc Hưng', 1, 0, N'mailhung@gmail.com', N'0623746422', N'123', NULL, 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (12, N'Nguyễn Ngọc Cẩm Tú', 1, 0, N'mailcamtu@gmail.com', N'0675638578', N'123', NULL, 0, 0, 0, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (13, N'Nguyễn Trường Giang', 1, 0, N'mailtruonggiang@gmail.com', N'0563579879', N'123', NULL, 0, 0, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (14, N'Hồ Trương Tú', 1, 0, N'mailtruongtu@gmail.com', N'0879864943', N'123', NULL, 0, 1, 1, N'590 CMT8 TPHCM', CAST(N'2021-07-23T05:40:00.0000000' AS DateTime2), N'/img/User/CMNDfront.jpg', N'/img/User/CMNDback.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (26, N'Tống Trọng Nhân', 1, 0, N'tongtrongnhan@gmail.com', N'0934995224', N'123', N'/img/User/image.png', 0, 0, 1, N'590 - CMT8', CAST(N'1990-01-01T07:00:00.0000000' AS DateTime2), N'/img/User/CMNDback.jpg', N'/img/User/CMNDfront.jpg')
INSERT [dbo].[User] ([userid], [username], [isemployee], [islead], [email], [phone], [password], [avatar], [isdeleted], [isfreelancer], [gender], [address], [birthday], [cmndbefore], [cmndafter]) VALUES (27, N'Nguyễn Văn A', 1, 0, N'nguyenan@gmail.com', N'0934995224', N'123', N'/img/User/a1.jpg', 0, 0, 0, N'590 - CMT8', CAST(N'1990-01-01T07:00:00.0000000' AS DateTime2), N'/img/User/CMNDback.jpg', N'/img/User/CMNDfront.jpg')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserExaminationAnswers] ON 

INSERT [dbo].[UserExaminationAnswers] ([UserExaminationAnswerId], [UserExaminationId], [QuestionId], [AnswerContent], [IsRightAnswer], [IsEssayAnswer], [Score], [ExaminationQuestionsActiveId]) VALUES (1, 3, 0, N'5', 1, 0, 2, 2)
INSERT [dbo].[UserExaminationAnswers] ([UserExaminationAnswerId], [UserExaminationId], [QuestionId], [AnswerContent], [IsRightAnswer], [IsEssayAnswer], [Score], [ExaminationQuestionsActiveId]) VALUES (2, 3, 0, N'11', 1, 0, 1, 3)
INSERT [dbo].[UserExaminationAnswers] ([UserExaminationAnswerId], [UserExaminationId], [QuestionId], [AnswerContent], [IsRightAnswer], [IsEssayAnswer], [Score], [ExaminationQuestionsActiveId]) VALUES (3, 3, 0, N'13', 1, 0, 1, 4)
INSERT [dbo].[UserExaminationAnswers] ([UserExaminationAnswerId], [UserExaminationId], [QuestionId], [AnswerContent], [IsRightAnswer], [IsEssayAnswer], [Score], [ExaminationQuestionsActiveId]) VALUES (4, 3, 0, N'3', 0, 0, 0, 0)
INSERT [dbo].[UserExaminationAnswers] ([UserExaminationAnswerId], [UserExaminationId], [QuestionId], [AnswerContent], [IsRightAnswer], [IsEssayAnswer], [Score], [ExaminationQuestionsActiveId]) VALUES (5, 3, 0, N'17', 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[UserExaminationAnswers] OFF
GO
SET IDENTITY_INSERT [dbo].[UserExaminations] ON 

INSERT [dbo].[UserExaminations] ([UserExaminationId], [UserId], [ExamId], [StatusEnumValue], [Score], [CreatedAt], [TimeConsumed], [ResultEnumValue], [UserExaminationGuid], [UserMarkStringList], [UserMarkedId], [ContentProviderId], [partnerid]) VALUES (3, 1, 1, 1, 4, CAST(N'2021-07-24T15:39:45.1111844' AS DateTime2), 23, 2, N'fef211a0-4ac2-4e11-9ac3-57e8f878880e', NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[UserExaminations] OFF
GO
SET IDENTITY_INSERT [dbo].[Userrole] ON 

INSERT [dbo].[Userrole] ([userroleid], [name], [displayname], [isprivate]) VALUES (1, N'PM', N'PM', 0)
INSERT [dbo].[Userrole] ([userroleid], [name], [displayname], [isprivate]) VALUES (2, N'Leader', N'Leader', 0)
INSERT [dbo].[Userrole] ([userroleid], [name], [displayname], [isprivate]) VALUES (3, N'Developer', N'Developer', 0)
INSERT [dbo].[Userrole] ([userroleid], [name], [displayname], [isprivate]) VALUES (4, N'Partner', N'Partner', 0)
SET IDENTITY_INSERT [dbo].[Userrole] OFF
GO
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (1, 1)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (2, 2)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (3, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (4, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (6, 2)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (7, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (9, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (10, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (11, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (12, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (13, 3)
INSERT [dbo].[Useruserrole] ([userid], [userroleid]) VALUES (14, 3)
GO
SET IDENTITY_INSERT [dbo].[Zoom] ON 

INSERT [dbo].[Zoom] ([zoomid], [zoomtitle], [zoomcode], [zoomstarturl], [zoomhost], [zoomjoinurl], [zoomagenda], [zoomstarttime], [zoompass], [zoomteam], [zoommember], [zoomcreateat], [zoomupdateat]) VALUES (1, N'FourN', N'0', N'https://us04web.zoom.us/s/71002594612?zak=eyJ0eXAiOiJKV1QiLCJzdiI6IjAwMDAwMSIsInptX3NrbSI6InptX28ybSIsImFsZyI6IkhTMjU2In0.eyJhdWQiOiJjbGllbnRzbSIsInVpZCI6ImtEXzBjUUFoUUl5QkgxblVyajlMbmciLCJpc3MiOiJ3ZWIiLCJzdHkiOjEwMCwid2NkIjoidXMwNCIsImNsdCI6MCwic3RrIjoibzd1RVYwQUZqaEVSaFg5SUZDclpmc2VWRzhiSkM5cEpqZGphUVlHdzRMby5CZ1lzTjJ3MlozSkNaWEZJYlVwblZYSTJSV3QyY25aSlkwdzBja2s1UTBGWFMyMXFabmR6TVZaUVNtVkRTVDFBTXpNM1pXVTBZbVpoTm1FMll6aGlNRFUxT1RJNU9XVmhOR1JtTTJVM05HVTNaRGt4WWpObE1UWm1OelUxTVRreFpUQXpORFJrTWpnNFpqTmtZamcxTndBTU0wTkNRWFZ2YVZsVE0zTTlBQVIxY3pBMEFBQUJlc2JFUkhvQUVuVUFBQUEiLCJleHAiOjE2MjY4Mzk1ODksImlhdCI6MTYyNjgzMjM4OSwiYWlkIjoibTI0M1MyZDFSQWVMYkpMNHJ0OFR2dyIsImNpZCI6IiJ9.7wTPCchFrzT5CIvoBe2ATw38hJ0oj51K9yAKRpLhdAE', 6, N'https://us04web.zoom.us/j/71002594612?pwd=eXI2ZzVhOUtYN3pmZ2N4akp0cDR1QT09', N'meeting about testing', N'2021-07-21T16:00:00', N'123', 0, 2, N'21-Jul-21 8:53:08 AM', N'21-Jul-21 8:53:08 AM')
INSERT [dbo].[Zoom] ([zoomid], [zoomtitle], [zoomcode], [zoomstarturl], [zoomhost], [zoomjoinurl], [zoomagenda], [zoomstarttime], [zoompass], [zoomteam], [zoommember], [zoomcreateat], [zoomupdateat]) VALUES (2, N'Interview', N'1', N'https://us04web.zoom.us/s/74154924906?zak=eyJ0eXAiOiJKV1QiLCJzdiI6IjAwMDAwMSIsInptX3NrbSI6InptX28ybSIsImFsZyI6IkhTMjU2In0.eyJhdWQiOiJjbGllbnRzbSIsInVpZCI6ImtEXzBjUUFoUUl5QkgxblVyajlMbmciLCJpc3MiOiJ3ZWIiLCJzdHkiOjEwMCwid2NkIjoidXMwNCIsImNsdCI6MCwic3RrIjoiLVhxNVhUT0RNWi14XzdDeFJKbndscEptV01kUXVOclpwR3JDa1E0UFRBWS5CZ1lzTjJ3MlozSkNaWEZJYlVwblZYSTJSV3QyY25aSlkwdzBja2s1UTBGWFMyMXFabmR6TVZaUVNtVkRTVDFBTXpNM1pXVTBZbVpoTm1FMll6aGlNRFUxT1RJNU9XVmhOR1JtTTJVM05HVTNaRGt4WWpObE1UWm1OelUxTVRreFpUQXpORFJrTWpnNFpqTmtZamcxTndBTU0wTkNRWFZ2YVZsVE0zTTlBQVIxY3pBMEFBQUJlc2MwUXVNQUVuVUFBQUEiLCJleHAiOjE2MjY4NDY5MjgsImlhdCI6MTYyNjgzOTcyOCwiYWlkIjoibTI0M1MyZDFSQWVMYkpMNHJ0OFR2dyIsImNpZCI6IiJ9.3_tZeD51lCAGqVHuUXgGeb5wKqZNVQNiX3wy44YK9Wg', 2, N'https://us04web.zoom.us/j/74154924906?pwd=eHdHV3VOWVFJNko3UGVUd3hydUUyQT09', N'interview with new member', N'2021-07-23T14:00:00', N'123', 2, 0, N'21-Jul-21 10:55:28 AM', N'21-Jul-21 10:55:28 AM')
SET IDENTITY_INSERT [dbo].[Zoom] OFF
GO
ALTER TABLE [dbo].[Affairs] ADD  CONSTRAINT [DF__Affairs__endtime__32E0915F]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [endtimeplan]
GO
ALTER TABLE [dbo].[Groups] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isdeleted]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF__Projects__endpla__34C8D9D1]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [endplan]
GO
ALTER TABLE [dbo].[Projects] ADD  CONSTRAINT [DF__Projects__startp__35BCFE0A]  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [startplan]
GO
ALTER TABLE [dbo].[Request] ADD  CONSTRAINT [DF_Request_reply]  DEFAULT ((0)) FOR [reply]
GO
ALTER TABLE [dbo].[User] ADD  DEFAULT (CONVERT([bit],(0))) FOR [isdeleted]
GO
ALTER TABLE [dbo].[Affairs]  WITH CHECK ADD  CONSTRAINT [FK_Affairs_Projects_projectid] FOREIGN KEY([projectid])
REFERENCES [dbo].[Projects] ([projectid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Affairs] CHECK CONSTRAINT [FK_Affairs_Projects_projectid]
GO
ALTER TABLE [dbo].[Affairs]  WITH CHECK ADD  CONSTRAINT [FK_Affairs_User_userid] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([userid])
GO
ALTER TABLE [dbo].[Affairs] CHECK CONSTRAINT [FK_Affairs_User_userid]
GO
ALTER TABLE [dbo].[Answers]  WITH CHECK ADD  CONSTRAINT [FK_Answers_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[Answers] CHECK CONSTRAINT [FK_Answers_Questions]
GO
ALTER TABLE [dbo].[Authcontroller]  WITH CHECK ADD  CONSTRAINT [FK_Authcontroller_Authapplication_authapplicationid] FOREIGN KEY([authapplicationid])
REFERENCES [dbo].[Authapplication] ([authapplicationid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authcontroller] CHECK CONSTRAINT [FK_Authcontroller_Authapplication_authapplicationid]
GO
ALTER TABLE [dbo].[Authuser]  WITH CHECK ADD  CONSTRAINT [FK_Authuser_Authapplication_authappliactionid] FOREIGN KEY([authappliactionid])
REFERENCES [dbo].[Authapplication] ([authapplicationid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authuser] CHECK CONSTRAINT [FK_Authuser_Authapplication_authappliactionid]
GO
ALTER TABLE [dbo].[Authuser]  WITH CHECK ADD  CONSTRAINT [FK_Authuser_User_userid] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([userid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authuser] CHECK CONSTRAINT [FK_Authuser_User_userid]
GO
ALTER TABLE [dbo].[Authuserrole]  WITH CHECK ADD  CONSTRAINT [FK_Authuserrole_Authapplication_authapplicationid] FOREIGN KEY([authapplicationid])
REFERENCES [dbo].[Authapplication] ([authapplicationid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authuserrole] CHECK CONSTRAINT [FK_Authuserrole_Authapplication_authapplicationid]
GO
ALTER TABLE [dbo].[Authuserrole]  WITH CHECK ADD  CONSTRAINT [FK_Authuserrole_Userrole_userroleid] FOREIGN KEY([userroleid])
REFERENCES [dbo].[Userrole] ([userroleid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Authuserrole] CHECK CONSTRAINT [FK_Authuserrole_Userrole_userroleid]
GO
ALTER TABLE [dbo].[ExaminationQuestions]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationQuestions_Examinations] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Examinations] ([ExamId])
GO
ALTER TABLE [dbo].[ExaminationQuestions] CHECK CONSTRAINT [FK_ExaminationQuestions_Examinations]
GO
ALTER TABLE [dbo].[ExaminationQuestions]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationQuestions_Questions] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[Questions] ([QuestionId])
GO
ALTER TABLE [dbo].[ExaminationQuestions] CHECK CONSTRAINT [FK_ExaminationQuestions_Questions]
GO
ALTER TABLE [dbo].[ExaminationQuestionsActives]  WITH CHECK ADD  CONSTRAINT [FK_ExaminationQuestionsActives_Examinations] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Examinations] ([ExamId])
GO
ALTER TABLE [dbo].[ExaminationQuestionsActives] CHECK CONSTRAINT [FK_ExaminationQuestionsActives_Examinations]
GO
ALTER TABLE [dbo].[Examinations]  WITH CHECK ADD  CONSTRAINT [FK_Examinations_Partner] FOREIGN KEY([UserId])
REFERENCES [dbo].[Partner] ([partnerid])
GO
ALTER TABLE [dbo].[Examinations] CHECK CONSTRAINT [FK_Examinations_Partner]
GO
ALTER TABLE [dbo].[Groupuser]  WITH CHECK ADD  CONSTRAINT [FK_Groupuser_Groups_groupid] FOREIGN KEY([groupid])
REFERENCES [dbo].[Groups] ([groupid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groupuser] CHECK CONSTRAINT [FK_Groupuser_Groups_groupid]
GO
ALTER TABLE [dbo].[Groupuser]  WITH CHECK ADD  CONSTRAINT [FK_Groupuser_User_userid] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([userid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Groupuser] CHECK CONSTRAINT [FK_Groupuser_User_userid]
GO
ALTER TABLE [dbo].[Partner]  WITH CHECK ADD  CONSTRAINT [FK_Partner_Departmentpartner_departmentpartnerid] FOREIGN KEY([departmentpartnerid])
REFERENCES [dbo].[Departmentpartner] ([departmentpartnerid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Partner] CHECK CONSTRAINT [FK_Partner_Departmentpartner_departmentpartnerid]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD  CONSTRAINT [FK_Request_User_userid] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([userid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Request] CHECK CONSTRAINT [FK_Request_User_userid]
GO
ALTER TABLE [dbo].[UserExaminationAnswers]  WITH CHECK ADD  CONSTRAINT [FK_UserExaminationAnswers_UserExaminations] FOREIGN KEY([UserExaminationId])
REFERENCES [dbo].[UserExaminations] ([UserExaminationId])
GO
ALTER TABLE [dbo].[UserExaminationAnswers] CHECK CONSTRAINT [FK_UserExaminationAnswers_UserExaminations]
GO
ALTER TABLE [dbo].[UserExaminations]  WITH CHECK ADD  CONSTRAINT [FK_UserExaminations_Examinations] FOREIGN KEY([ExamId])
REFERENCES [dbo].[Examinations] ([ExamId])
GO
ALTER TABLE [dbo].[UserExaminations] CHECK CONSTRAINT [FK_UserExaminations_Examinations]
GO
ALTER TABLE [dbo].[UserExaminations]  WITH CHECK ADD  CONSTRAINT [FK_UserExaminations_Partner1] FOREIGN KEY([partnerid])
REFERENCES [dbo].[Partner] ([partnerid])
GO
ALTER TABLE [dbo].[UserExaminations] CHECK CONSTRAINT [FK_UserExaminations_Partner1]
GO
ALTER TABLE [dbo].[Useruserrole]  WITH CHECK ADD  CONSTRAINT [FK_Useruserrole_User_userid] FOREIGN KEY([userid])
REFERENCES [dbo].[User] ([userid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Useruserrole] CHECK CONSTRAINT [FK_Useruserrole_User_userid]
GO
ALTER TABLE [dbo].[Useruserrole]  WITH CHECK ADD  CONSTRAINT [FK_Useruserrole_Userrole_userroleid] FOREIGN KEY([userroleid])
REFERENCES [dbo].[Userrole] ([userroleid])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Useruserrole] CHECK CONSTRAINT [FK_Useruserrole_Userrole_userroleid]
GO
