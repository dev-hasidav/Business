use [StwPh_25122304_2020]
SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet,
a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB, a.Ucetni, a.Creator, a.NullCheck_Cislo
FROM  AD AS a LEFT OUTER JOIN sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID where (a.ICO IS NOT NULL) ORDER BY a.ICO

--use [StwPh_28447816_2020]
--SELECT  a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme,
--			a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.Ucetni, a.Creator, a.Pozn, NullCheck_Cislo
--FROM AD as a ORDER BY a.ICO

--use [StwPh_28890060_2020]
--SELECT  a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme,
--			a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.Ucetni, a.Creator, a.Pozn, NullCheck_Cislo
--FROM AD as a ORDER BY a.ICO

--use [StwPh_28910419_2020]
--SELECT  a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme,
--			a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.Ucetni, a.Creator, a.Pozn, NullCheck_Cislo
--FROM AD as a ORDER BY a.ICO

use [StwPh_00000010_2020]
--DELETE FROM AD
SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet,
a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB, a.Ucetni, a.Creator, a.NullCheck_Cislo
FROM  AD AS a LEFT OUTER JOIN      sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN       sZeme AS c ON a.RefZeme = c.ID ORDER BY a.ICO

--use [StwPh_00000011_2020]
--DELETE FROM AD
--SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet,
--a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB, a.Ucetni, a.Creator, a.NullCheck_Cislo
--FROM  AD AS a LEFT OUTER JOIN sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN sZeme AS c ON a.RefZeme = c.ID  where (a.ICO is not null) ORDER BY a.ICO

--use [StwPh_00000012_2020]
--DELETE FROM AD
--SELECT  a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme,
--			a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.Ucetni, a.Creator, a.Pozn, NullCheck_Cislo
--FROM AD as a ORDER BY a.ICO

--use [StwPh_00000013_2020]
--DELETE FROM AD
--SELECT  a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RefZeme,
--			a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.Ucetni, a.Creator, a.Pozn, NullCheck_Cislo
--FROM AD as a ORDER BY a.ICO

--use [StwPh_00000014_2020]
--DELETE FROM AD
--SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet,
--a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB, a.Ucetni, a.Creator, a.NullCheck_Cislo
--FROM  AD AS a LEFT OUTER JOIN      sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN       sZeme AS c ON a.RefZeme = c.ID  ORDER BY a.ICO

--use [StwPh_00000015_2020]
--DELETE FROM AD
--SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet,
--a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB, a.Ucetni, a.Creator, a.NullCheck_Cislo
--FROM  AD AS a LEFT OUTER JOIN      sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN       sZeme AS c ON a.RefZeme = c.ID  ORDER BY a.ICO

/*
SELECT p.id, p.name, p.display_name, p.x_jmeno, p.vat, p.street, p.zip, p.city, p.phone, p.mobile, p.email, p.website, p.comment, p.active, 
p.x_dic, pb.acc_number as Ucet, b.x_ids as KodBanky, p.country_id , c.code AS Country,
pb.bank_id as bank_id, b.name as nameB, pb.sequence
FROM res_partner p 
    LEFT OUTER JOIN res_country c ON p.country_id = c.ID
    LEFT OUTER JOIN res_partner_bank pb ON pb.partner_id = p.ID
    LEFT OUTER JOIN res_bank b ON pb.bank_id = b.ID
--WHERE (p.id = 222)
order by p.vat

DELETE FROM res_partner
 where 
--(id > 100) AND 
(id > 222)

*/
