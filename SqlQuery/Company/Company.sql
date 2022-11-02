use [StwPh_25122304_2020]

SELECT        IDS, SText, IBAN, Banka, KodBanky, Swift
FROM            sUcet AS u
where IBAN IS NOT NULL
ORDER BY IDS

use [StwPh_sys]

SELECT f.ID, f.ICO, f.DIC, f.Firma, f.RefZeme, f.Jmeno, f.Prijm, f.Ulice, f.CP, f.Obec,
                        f.PSC, f.Tel, f.GSM, f.Email, f.WWW, f.Soubor, f.Pozn, f.Rok, f.DatRokOd, f.DatRokDo,
                        z.IDS, z.SText, z.Kod 
                        FROM Firma AS f LEFT OUTER JOIN sZeme AS z ON f.RefZeme = z.ID 
						order by f.Rok DESC, f.Firma




