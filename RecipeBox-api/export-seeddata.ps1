$tables = @("Subject", "Widget")

foreach ($table in $tables) {
	echo "exporting $table..."
	$sql = "SELECT * FROM RecipeBox.dbo.$table"
	$filename = "src\\Acme.RecipeBox.WebApi.IntegrationTests\\SeedData\\$table.csv"
	Invoke-Sqlcmd -Query $sql -HostName localhost | Export-Csv -Path $filename -NoTypeInformation
}

