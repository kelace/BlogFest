CREATE TRIGGER [DELETE_POST]
	on dbo.Posts
	INSTEAD OF DELETE
as
BEGIN
	DECLARE @PostId uniqueidentifier;
	SELECT @PostId = Id from DELETED
	DELETE FROM dbo.PostReactions Where PostId = @PostId
	DELETE FROM dbo.Posts Where Id = @PostId
END
go

CREATE TRIGGER [DELETE_USER]
	on dbo.Users
	INSTEAD OF DELETE
as
BEGIN
	DECLARE @UserId uniqueidentifier;
	SELECT @UserId = Id from DELETED
	DELETE FROM dbo.PostReactions Where UserId = @UserId
	DELETE FROM dbo.Posts Where UserId = @UserId
	DELETE FROM dbo.AspNetUserRoles Where UserId = @UserId
	DELETE FROM dbo.Users Where Id = @UserId
END
go

CREATE TRIGGER [DELETE_UserFiles]
	on dbo.UserFiles
	INSTEAD OF DELETE
as
BEGIN
	DECLARE @UserFileId uniqueidentifier;
	SELECT @UserFileId = Id from DELETED;

	DECLARE @FileId uniqueidentifier;
	SELECT @FileId = f.FileId from (select FileId from dbo.UserFiles where Id = @UserFileId) as f;

	DELETE FROM dbo.UserFiles Where Id = @UserFileId
	DELETE FROM dbo.Files Where Id = @FileId
END
go