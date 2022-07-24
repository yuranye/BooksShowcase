ALTER TABLE books_keyspace.books
    ADD (description text, publish_date timestamp, pages int, language text, ean_upc text, type int, price float, publishers frozen<list<publisher>>, authors frozen<list<author>>)
