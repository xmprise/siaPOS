# siaPOS

POS 프로그램은 Windows Application으로 작성되었고 DB는 MS-SQL Server을 사용하였다. 데이터베이스 I/O는 인라인 코딩을 하지 않고 
Stored Procedure와 Trigger를 사용해 처리하였다. 
Stored Procedure는 TSQL과 C#으로 CLR Stored Procedure 을 만들어 dll파일을 DBMS에 주입하는 방식을 사용하였다. 
WEB 부분은 ASP를 이용하였으며, 디자인은 css 스타일시트와 PhotoShop을 사용했다. WEB 부분은 Windows Application에서 
수집된 데이터를 조회하고 분석하는 역할을 담당하는데 데이터베이스에 자료를 수정하거나 삭제하는 부분은 Stored Procedure로 처리하고 
조회나 연산과 관련된 부분은 LINQ기술을 이용하였다. 
Mobile은 Android 플랫폼을 기반으로 하며, 사용자의 편의를 위해 매출과 관련된 데이터를 조회 할 수 있는 역할을 수행한다. 
WSDL기술을 이용해 Android Application에서 method를 호출하면 SOAP방식으로 데이터를 받게 되고 
ksoap2 라이브러리를 활용하여 parsing한다. 
