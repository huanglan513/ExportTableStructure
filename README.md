# ExportTableStructure
导出某个数据库的所有表结构
有的时候需要给别人看数据库的表结构，放到Excel表中。做了一个简单版的，还能看。格式如下，Excel中复制过来的，有点不整齐<br>
表名	字段序号	字段名	标识	主键	类型	占用字节数	字段定义的长度	小数点后位数	是否允许空	默认值	字段说明<br>
CFG_AchievementReportRecord	1	ItemID			nvarchar	100	50	0		(newid())	记录ID<br>
CFG_AchievementReportRecord	2	ReportDate			date	3	10	0			上报日期<br>
CFG_AchievementReportRecord	3	IsAchievementReport			smallint	2	5	0		((0))	是否已经上报<br>
CFG_AchievementReportRecord	4	ModDate			datetime	8	23	3		(getdate())	数据修改时间<br>
CFG_AssureCompanyBank	1	ItemID			nvarchar	100	50	0		(newid())	数据ID<br>
CFG_AssureCompanyBank	2	AssureCompany			nvarchar	100	50	0			担保公司<br>
