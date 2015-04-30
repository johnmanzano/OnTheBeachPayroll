CREATE PROCEDURE EmployeesSalary
(
	@name varchar(255)=ull
)
AS
BEGIN
	SELECT 
		e.id as employeee_id,
		e.name, 
		cast(s.annual_amount / c.conversion_factor as  decimal(18,2)) as annual_amount
	FROM
		Employees e
		JOIN Salaries s on s.employee_id = e.id
		JOIN Currencies c on c.id = s.currency_id
	WHERE
		@name is null or
		e.name = @name
END
