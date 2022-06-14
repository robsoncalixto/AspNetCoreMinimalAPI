create or replace procedure GetUserByName(p_username    in varchar2,
											 p_user_cursor out sys_refcursor  
) AS 
BEGIN
    OPEN p_user_cursor FOR
		SELECT u.username , u.name, u.details FROM user u WHERE u.username = p_username;
END;
/

create or replace function GetUsers return sys_refcursor
is 
result sys_refcursor;
BEGIN
    OPEN result FOR
		SELECT u.username , u.name, u.details FROM user u;
    return result;
END;
/
