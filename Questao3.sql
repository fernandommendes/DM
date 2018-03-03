SELECT c.nome            AS "Nome Cliente",
       c.CNPJ            AS CNPJ,
       p.numeroPed       AS Numero,
       p.[data]          AS DATA,
       CASE WHEN p.valorTotal IS NULL THEN 0
            ELSE p.valorTotal
       END               AS Valor
FROM   Cliente           AS c
       LEFT JOIN Pedido  AS p
            ON  p.codigoCli = c.codigoCli
ORDER BY c.nome, p.[data] DESC