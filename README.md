MVC ADO.NET 與 Stored Procedure - Insert, Update, Delete綀習
=========================================================

##使用工具
------

*   Visual Studio 2017
*   ASP.NET MVC5
*   Sql Server 2014 Express

##系統擷圖
------

依部門讀取員工資料
=========

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/1_Employee_List.jpg)

員工新增
====

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/2_Employee_Create.jpg)

員工編輯
====

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/2_Employee_Edit.jpg)

資料庫專案
=====

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/501_Database_1.jpg)

讀取所有部門資料：usp\_GetAllDepartment
==============================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_1_usp_GetAllDepartment.jpg)

依部門編號讀取員工資料：usp\_GetEmployeeByDepId
===================================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_2_usp_GetEmployeeByDepId.jpg)

依員工編號讀取員工資料：usp\_GetEmployeeByEmpID
===================================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_3_usp_GetEmployeeByEmpID.jpg)

新增員工資料：usp\_PR\_Employee\_Insert
================================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_4_usp_PR_Employee_Insert.jpg)

編輯員工資料：usp\_PR\_Employee\_UpdateByPK
====================================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_5_usp_PR_Employee_UpdateByPK.jpg)

刪除員工資料：usp\_PR\_Employee\_DeleteByPK
====================================

![](https://raw.githubusercontent.com/ismeihchen/Image/master/Image/Images/StoredProcedure/ADONET/601_sp_6_usp_PR_Employee_DeleteByPK.jpg)

##參考資料
------

*   跟著實務學習ASP.NET MVC：第一次寫MVC就上手(第7章-範例程式)[https://www.books.com.tw/products/0010776836](https://www.books.com.tw/products/0010776836)
*   ASP.NET MVC 4 開發實戰(保哥)-範例程式[https://www.delightpress.com.tw/book.aspx?book\_id=SKNP00028](https://www.delightpress.com.tw/book.aspx?book_id=SKNP00028)
*   mrkt 的程式學習筆記[http://kevintsengtw.blogspot.com/2013/03/entity-framework-stored-procedure.html](http://kevintsengtw.blogspot.com/2013/03/entity-framework-stored-procedure.html)
*   How to implement ADO.NET with Generic Repository?[https://stackoverflow.com/questions/42577391/how-to-implement-ado-net-with-generic-repository](https://stackoverflow.com/questions/42577391/how-to-implement-ado-net-with-generic-repository)