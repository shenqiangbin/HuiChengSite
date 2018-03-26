/*SqlLite脚本*/

/*文章*/
CREATE TABLE [Article] (
  [ArticleId] INTEGER PRIMARY KEY AUTOINCREMENT, 
  [Title] NVARCHAR(50) NOT NULL, 
  [Content] nvARCHAR(5000) NOT NULL,   
  [ContentLevel] int NOT NULL,   
  [PublishStatus] int NOT NULL,
  [DisplayCreatedTime] DATETIME NOT NULL, 
  [CreatedTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME, 
  [Enable] INT NOT NULL);

/*文章增加【创建人】字段*/
ALTER TABLE Article ADD COLUMN CreateUser nvarchar(50)
UPDATE Article set createuser  = 'shenqiangbin@163.com'
/*文章增加【关键字(在页的meta中使用)，url标题（重写url时使用），utl标题数字（加速搜索时使用）】字段*/
ALTER TABLE Article ADD COLUMN KeyWords nvarchar(50);
ALTER TABLE Article ADD COLUMN UrlTitle nvarchar(50);
ALTER TABLE Article ADD COLUMN UrlTitleNum nvarchar(50);


/*分类*/
drop table if exists [Label];
CREATE TABLE [Label] (
  [LabelId] INTEGER PRIMARY KEY AUTOINCREMENT, 
  [Name] NVARCHAR(50) NOT NULL UNIQUE,  
  [CreateUser] string not null,
  [CreateTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME, 
  [Enable] INT NOT NULL);

  /*文章&标签关系表*/
drop table if exists [ArticleLabel];
CREATE TABLE [ArticleLabel] (
  [LabelId] INTEGER,
  [ArticleId] INTEGER,
  [CreateUser] string not null,
  [CreateTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME, 
  [Enable] INT NOT NULL);

drop table if exists User;

-- '用户表';
create table User
(
   UserID     					int not null, --'用户唯一标识',
   Email								varchar(50) not null UNIQUE, -- '邮箱',
   UserName							nvarchar(50) not null, -- '用户名',
   Password							varchar(200) not null, -- '密码',
   Salt									varchar(37) not null, -- '盐',
   Phone								varchar(20) not null default '', -- '手机',   
   CreatedTime           datetime, -- '创建时间',
   UpdateTime          datetime, -- '修改时间',
   Enable               int, -- '状态：0删除，1未删除',
   primary key (UserID)
);

drop table if exists Log;
-- '日志表';
create table Log
(
   LogID     					INTEGER PRIMARY KEY AUTOINCREMENT,  --'日志唯一标识',
   Date						    datetime, -- '日期',
   Level						nvarchar(50), -- '级别',
   Logger						nvarchar(50), -- 'Logger',
   Message						text -- '信息',
);

/*评论*/
drop table if exists [Comment];
CREATE TABLE [Comment] (
  [CommentId] INTEGER PRIMARY KEY AUTOINCREMENT, 
  [ArticleId] INTEGER NOT NULL,
  [UserName] NVARCHAR(50),
  [Content] NVARCHAR(50),
  [ParentId] INTEGER,
  [CreateTime] DATETIME NOT NULL, 
  [UpdateTime] DATETIME, 
  [Enable] INT NOT NULL);
