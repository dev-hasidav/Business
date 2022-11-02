use [StwPh_25122304_2020]
--DELETE FROM sZeme
SELECT ID, SText, IDS, Kod, RelZeme, Pozn, Ucetni, Creator FROM  sZeme ORDER BY IDS

--DELETE FROM sCMeny
SELECT ID, IDS, Kod, Pouzit, Zeme, Mnozstvi, Pozn, Ucetni, Creator FROM sCMeny ORDER BY Kod

--DELETE FROM sBanky
SELECT ID, IDS, SText, SWIFT, KodZeme, Sel, WWW, Pozn, Ucetni, Creator FROM sBanky ORDER BY IDS

--DELETE FROM AD
SELECT        a.ID, a.Cislo, a.Firma, a.Jmeno, a.ICO, a.Ulice, a.PSC, a.Obec, a.Tel, a.GSM, a.Email, a.WWW, a.Pozn, a.Sel, a.RelCR, a.DIC, a.Ucet, a.KodBanky, a.RefZeme, c.IDS, b.ID AS IdBank, b.SText as nameB,
a.Ucetni, a.Creator, a.NullCheck_Cislo
FROM            AD AS a LEFT OUTER JOIN
                         sBanky AS b ON a.KodBanky = b.IDS LEFT OUTER JOIN
                         sZeme AS c ON a.RefZeme = c.ID
ORDER BY a.ICO



