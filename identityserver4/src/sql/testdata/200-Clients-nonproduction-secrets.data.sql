UPDATE [AUTH].[ClientSecrets]
SET [Value] = N'K7gNU3sdo+OL0wNhqoVWhr3g6s1xYv72ol/pe/Unols=' --secret
FROM
    [AUTH].[Clients] C
    inner join [AUTH].[ClientSecrets] CS on C.Id = CS.ClientId
WHERE
    C.ClientId in ('system', 'recipeBox-service', 'recipeBox-web')

