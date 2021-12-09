USE [FourN6]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/20/2021 9:16:03 PM ******/
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
/****** Object:  Table [dbo].[Affairs]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[AnswerActives]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Answers]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Authapplication]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Authcontroller]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Authuser]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Authuserrole]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Chatroom]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Departmentpartner]    Script Date: 7/20/2021 9:16:04 PM ******/
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
 CONSTRAINT [PK_Departmentpartner] PRIMARY KEY CLUSTERED 
(
	[departmentpartnerid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Documents]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[ExaminationQuestions]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[ExaminationQuestionsActives]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Examinations]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Groups]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Groupuser]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Interview]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Notification]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Partner]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Privatemessage]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Projectgroup]    Script Date: 7/20/2021 9:16:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Projectgroup](
	[projectid] [int] NOT NULL,
	[groupid] [int] NULL,
 CONSTRAINT [PK_Projectgroup] PRIMARY KEY CLUSTERED 
(
	[projectid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Projects]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Questions]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[QuestionsActices]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Request]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Tests]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 7/20/2021 9:16:04 PM ******/
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
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserExaminationAnswers]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[UserExaminations]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Userrole]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Useruserrole]    Script Date: 7/20/2021 9:16:04 PM ******/
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
/****** Object:  Table [dbo].[Zoom]    Script Date: 7/20/2021 9:16:04 PM ******/
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
