﻿CREATE TABLE [dbo].[Publisher] (
    [PublisherID] [int] NOT NULL,
    [PublisherName] [varchar](20),
    [Country] [varchar](20),
    CONSTRAINT [PK_dbo.Publisher] PRIMARY KEY ([PublisherID])
)
ALTER TABLE [dbo].[Book] ADD [PublisherID] [int] NOT NULL DEFAULT 0
CREATE INDEX [IX_PublisherID] ON [dbo].[Book]([PublisherID])
ALTER TABLE [dbo].[Book] ADD CONSTRAINT [FK_dbo.Book_dbo.Publisher_PublisherID] FOREIGN KEY ([PublisherID]) REFERENCES [dbo].[Publisher] ([PublisherID]) ON DELETE CASCADE
INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
VALUES (N'202107051455513_02_Book_Publisher', N'EFCodeFirstAssignment.Migrations.Configuration',  0x1F8B0800000000000400DD5B5F4FE436107FAFD4EF10E5B1E208703AA945BB77E216A8500F38B170EA1B32C9EC129DE3A4B1C3B1AAFAC9FAD08FD4AF503B8913278EF38FB0D0132F107BC6F3E7E7F178C6FCFBF73FB30F8F01B61E20A67E48E6F6FEEE9E6D017143CF27EBB99DB0D59B9FED0FEF7FFC6176E2058FD61739EFAD98C729099DDBF78C45878E43DD7B0810DD0D7C370E69B862BB6E1838C80B9D83BDBD5F9CFD7D07380B9BF3B2ACD95542981F40FA07FF731112172296207C1E7A8069FE9D8F2C53AED6050A8046C885B97D72BAE0734EFD98B2234AFD35098030DB3AC23EE2C22C01AF6C0B111232C4B8A8873714962C0EC97A19F10F085F6F22E0F3560853C855382CA7F7D566EF4068E3948492959B5016060319EEBFCDCDE3D4C94719D92ECCC70D78C20DCD3642EBD48873FB63187EB5ADFA42870B1C8B4906FBEE0AAA1DAB716CA78005478FF8D9B1160966490C7302098B11DEB13E2777D8777F83CD75F815C89C2418AB527239F958E503FFF4390E2388D9E60A568AEC67C7B6E554699D3A71415AA3CB343C23ECED816D5D7021D01D86020C8A35962C8CE15720102306DE67C418C4DC971721016DF586B5C46F72358E3EBE976CEB1C3D7E02B266F773FB806F9E53FF113CF92117E086F87CE7711A16279DEBA426A5F710772B566374811EFC75AAA789A56D5D014E67D07B3FCA76550A815B65CA691C065721CE552E476E976112BB42FFB071F81AC56B6055A9664E89D356F42AEB0F857041FAF238AEF86E289807387E1A44170B6E03D68B901F0DF166F2658CA017E85C8418839B05DCA7205F42DB807CB9314621FF1C82BB31B0CFE85E1EF3991C63005F526E03EDD96AD343BDB7A3AFE0C1876FC31D9DD1BDBCA33339C638BAA4DC86A3B3D5AEE191B538FADD1431AD5FFAD10796D39DF542A6FDC66897D9E5369F50C63AF5BB76C657069B4EF8365932DD5AA529A668F2E4232689E4F090AC836F9BD0F55349146B29274055AF13E259ED8950862E79947080F1ADE7477CB3F1C5E7F64F9AA58C1C8B03A6E4A89C4B55B6FB767DAF5E9263C0C0C03A72B3BBC9025117793A6AB85DBCEA17BEBD21E67184DFA0F8658DF280E113A6C7029FB87E8470ABF035AAA1099210AF58A83E720C11108FCBD9EA9009242816AA19AECB4E334701573BE62AFBD0848FE64D59A2431E26FD11D7B8933B10FCF2506B92BA8F9B9B6F948330D6E482A72DBD3D70C9B0DA01062DC64E00B07A605678CA54F79582AC26791F5F9B92DF3140AB39E3A9CB4F0EB6EC4CE5348C5340ACA0FDF8A3F89A265C5A727B4321CF6F699E54D5F123B82E8155CA58E5F95D894E1AF6AAB4CA91A93150C63AB848946A2CE44007BDDC391ABD1CA8D12BE6AE9A41BD9A2A939A2FAF75FF77262F85D8D2E61A843AB3158585D9BC4E55BF1EBA5713555D73F301DA7D842A2237BBA3FBCCEC30DC78858B5CD8A8726358EF13D847A95D8FE40A13C35630AB2E53F2227C94AD0027EB05C89E8163681ACCCE5114F16B9CD244C8BF58CBAC83B078B31C5E570F321E8E4B1BCAEB85B4C54AFC5A8AD6501B15D5ADFC667E8C18BA43E2C2B6F0026D5A35581AC2885C4B8987BAAB64689193C5EF1981B9CEDF70A4E4E4A75C29312DD50FEA00D7C8D2FE0DC22836DC8717214E02D29E0DB573C9CA34753ED9D7FE9C2AB9BECAACF512203058B38B76B86A0ED0F292AA337BB9BA2D980FF5B791570FA7B7D04E6DE94E7E3A106A43FD79161568955BF1F1D5A0200FAD4F874033A31EFE37119A0C5B66A1AA65CDB9691727DDE7EAF757E3A8FC207DBAA39A19F5709489D064DEB20EAB1AD754D7EDE694D558755ED9F76111FFE9E7C670183E2B70B48CA73EA558BDC87C6A19CE2CCF36BADF4E68E94736C5B6B8891E7C4FA41ECB0D6510EC8A09BBCB3FF002FBE9F30A39E11C117F0594652D02FB606FFFA0F6F6E2F5BC837028F57043B6567F0C31A2C731CD43045F5876601FA0FEBCE001C5EE3D8AB5EE54C976E463825438ED9A7E463C789CDB7FA67487D6D9EFB70AE98E7519738C1C5A7BD65F1D8A8D68F88F70D3D47DF6310E6BEC9E4FE3B55AAF7C0CD3A1EDE7114E98AEF13BC6FC7A3BF759CDD474D46EBB6D3AC64C7A33B4C94CEF0643B421E0F5882919D58070D2133B3D96967413C4B2D16D44A548B6F5465FB59837A27739AAB2DE760D7DDEEEE0F7D40CECE5B167428B2C178E680D8DEE2D6FB7C3F7DD34F5645176BB1DB797838AB1C0F1AC7DBAFF4B634E2F491BAA1A7D1A6FD97D726E7B7721F76F76624ED9926BE23F61C7AE89FD54DDBC26DE2FD4E9D38CDDDE9A6B38639EADB7F5D4665E2FF11AA35167EBEB651B7655ECB634D726576E404B4E2F44F170A5FCAB0F0F95A29A59B010FFF843B287D7255339E78CAC4219316B12C9295ACECF90C7A3D851CCFC1572191F7681D2F44DE71784135159E526F3CEC865C2A244D456B90971A5AA2FE26EDBFA69DFB12AF3EC324A1F2D4EA10217D3E72AC025F998F8D82BE43E6DB876185888809EBF8815BE64E265EC7A5370D29FC69A18E5E62BCEA16B0822CC99D14BB2440F3046B61B0A9F608DDC8DAC279A99743BA26AF6D9B18FD6310A68CEA3A4E77F720C7BC1E3FBFF0046E539F8F1360000 , N'6.4.4')

select * from Publisher
select * from Book
select * from Review
select * from Member