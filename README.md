# DbTransfer
1. Спроектировала ненормализованную модель данных (предметная область - информация о студентах университета), нормализовала её до третьей нормальной формы. Устранены все функциональные и транзитивные зависимости. 
2. Разработала приложение, которое считывает ненормализованные данные (из SQLite) и экспортирует их в нормализованном виде (в PostgreSQL).
3. Не удалось произвести экспорт в табличный процессор (Excel).

Схема БД создается не из скрипта, а в ручном режиме. 
Запись БД защищена от дублирования строк (используется конструкция INSERT ... ON CONFLICT ... )

- Ненормализованная таблица:
<table class="table table-bordered table-hover table-condensed">
  <h2><b> Студенты </b><h2>
<table class="table table-bordered table-hover table-condensed">
<thead><tr><th title="Field #1">Фамилия</th>
<th title="Field #2">Зач.книжка</th>
<th title="Field #3">Группа</th>
<th title="Field #4">Факультет</th>
<th title="Field #5">Специальность</th>
<th title="Field #6">Кафедра</th>
<th title="Field #7">Телефон</th>
<th title="Field #8">Адрес факультета</th>
  
</tr></thead>
<tbody><tr>
<td>Иванов</td>
<td>ИТ100001</td>
<td>ИТ015</td>
<td>Мехмат</td>
<td>ФИТ</td>
<td>ИТ</td>
<td>123-001</td>
<td>Букирева,10</td>
</tr>
<tr>
<td>Петров</td>
<td>КБ100501</td>
<td>КБ014</td>
<td>Экономический</td>
<td>ЭКБ</td>
<td>КБ</td>
<td>123-005</td>
<td>Букирева,15</td>
</tr>
<tr>
<td>Сидоров</td>
<td>ИТ200002</td>
<td>ИТ014</td>
<td>Мехмат</td>
<td>ФИТ</td>
<td>ИТ</td>
<td>123-001</td>
<td>Букирева,10</td>
</tr>
<tr>
<td>Ботова</td>
<td>ИТ100000</td>
<td>ИТ013</td>
<td>Географический</td>
<td>ГИО</td>
<td>ГИ</td>
<td>123-123</td>
<td>Букирева,1</td>
</tr>
<tr>
<td>Попов</td>
<td>ИТ100003</td>
<td>ИТ032</td>
<td>Мехмат</td>
<td>ПМИ</td>
<td>ПМИ</td>
<td>666-666</td>
<td>Букирева,10</td>
</tr>
  </tbody></table>
  
  
  - Нормализованная в 5 таблицах:
      <table>
      <h2><b> Студенты </b><h2>
      <tr>
        <th>ФИО</th>
        <th>Зачетная книжка</th>
        <th>Группа</th>
      </tr>
        <tr><td>Иванов</td><td>ИТ100001</td><td>ИТ015</td></tr>
      <tr><td>Петров</td><td>КБ100501</td><td>КБ014</td></tr>
      <tr><td>Сидоров</td><td>ИТ200002</td><td>ИТ014</td></tr>
      <tr><td>Ботова</td><td>ИТ100000</td><td>ИТ013</td></tr>
      <tr><td>Попов</td><td>ИТ100003</td><td>ИТ032</td></tr>
      </table>
        <br><br>
        
      <table>
      <h2><b> Группа </b><h2>
      <tr>
        <th>Группа</th>
        <th>Специальность</th>
      </tr>
      <tr><td>ИТ100001</td><td>ФИТ</td></tr>
      <tr><td>КБ100501</td><td>ЭКБ</td></tr>
      <tr><td>ИТ200002</td><td>ФИТ</td></tr>
      <tr><td>ИТ100000</td><td>ГИО</td></tr>
      <tr><td>ИТ100003</td><td>ПМИ</td></tr>
      </table>
        <br><br> 
        
       <table>
      <h2><b> Специальность </b><h2>
      <tr>
        <th>Специальность</th>
        <th>Кафедра</th>
      </tr>
      <tr><td>ФИТ</td><td>ИТ</td></tr>
      <tr><td>ЭКБ</td><td>КБ</td></tr>
      <tr><td>ГИО</td><td>ГИ</td></tr>
      <tr><td>ПМИ</td><td>ПМИ</td></tr>
      </table>
        <br><br>    
        
       <table>
      <h2><b> Кафедра </b><h2>
      <tr>
        <th>Кафедра</th>
        <th>Телефон</th>
        <th>Факультет</th>
      </tr>
      <tr><td>ИТ</td><td>123-001</td><td>Мехмат</td></tr>
      <tr><td>КБ</td><td>123-005</td><td>Экономический</td></tr>
      <tr><td>ГИ</td><td>123-123</td><td>Географический</td></tr>
      <tr><td>ПМИ</td><td>666-666</td><td>Мехмат</td></tr>
      </table>
        <br><br>        
        
       <table>
      <h2><b> Факультет </b><h2>
      <tr>
        <th>Факультет</th>
        <th>Адрес</th>
      </tr>
      <tr><td>Мехмат</td><td>Букирева,10</td></tr>
      <tr><td>Экономический</td><td>Букирева,15</td></tr>
      <tr><td>Географический</td><td>Букирева,1</td></tr>
      </table>
        <br><br>         
