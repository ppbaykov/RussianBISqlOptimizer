# RussianBISqlOptimizer

На входе - SQL с вложенным SQL запросом.

```SQL
SELECT
    `Col1` AS `Attribute1`,
    `Col2` AS `Attribute2`,
    SUM(`Col3`) AS `Attribute3`
FROM
(
    SELECT
        `Column1` AS `Col1`,
        `Column2` AS `Col2`,
        `Column3` AS `Col3`
    FROM
        `Table`
    WHERE
        `Column1` = 1000
    GROUP BY
        `Column1`,
        `Column2`,
        `Column3`
)
GROUP BY
`Col1`,
`Col2`
```

Необходимо имплементировать метод `SqlOptimizer.Optimize` чтобы SQL был таким
(оптимизация SQL)

```sql
SELECT
    `Column1` AS `Attribute1`,
    `Column2` AS `Attribute2`,
    SUM(`Column3`) AS `Attribute3`
FROM
    `Table`
WHERE
    `Column1` = 1000
GROUP BY
    `Column1`,
    `Column2`
```