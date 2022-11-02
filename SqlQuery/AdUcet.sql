use [StwPh_00000010_2020]

SELECT        a.ID as a_ID, a.Firma, a.ICO, a.DIC, a.Ucet as a_Ucet, a.KodBanky as a_KodBanky, 
b1.ID AS b1_ID, b1.IDS b1_Ids, b1.SWIFT as b1_Swift, 
b2.ID AS b2_Id, b2.IDS AS b2_Ids, b2.SWIFT as b2_Swift, 
au.ID AS au_ID, au.Ucet AS ua_Ucet, au.KodBanky as au_KodBanky, 
b3.ID AS b3_ID, b3.IDS AS b3_Ids, b3.SWIFT AS b3_Swift, 
b4.ID AS b4_Id, b4.IDS AS b4_Ids, b4.SWIFT AS b4_Swift


FROM            sBanky AS b4 RIGHT OUTER JOIN
                         ADucet AS au ON b4.SWIFT = au.KodBanky LEFT OUTER JOIN
                         sBanky AS b3 ON au.KodBanky = b3.IDS RIGHT OUTER JOIN
                         AD AS a LEFT OUTER JOIN
                         sBanky AS b2 ON a.KodBanky = b2.SWIFT LEFT OUTER JOIN
                         sBanky AS b1 ON a.KodBanky = b1.IDS ON au.RefAg = a.ID


