# Massive PDF Printer
Starting on Windows 11, Windows stopped offering printing for a multiple file selection.

Because of this, and because my wife needed to print PDF files massively, I dedided to create this small application. Simply drag and drop the files you want to print into the white area, select a printer from the combobox / dropdown, and press the "Print" button. 

Printing is managed by the SumatraPDF executable, wich is built into the application. Because of this and to avoid creating printing dialogs, only PDF files are supported. Any other file extension will be ignored by the application and the printing process.


----

A partir de Windows 11 Windows parece haber dejado de ofrecer la opción de Imprimir cuando se seleccionan multiples archivos.

Por lo anterior (y por que mi esposa lo necesitaba) decidí hacer esta pequeña aplicación. Simplemente arrastra los archivos PDF que requieras imprimir, selecciona una impresora y presiona el botón de "Imprimir".

La impresión es detonada y administrada por SumatraPDF, que esta embedido en la aplicación. Por esto y para evitar la creación de dialogos de sistema, solo se permite imprimir PDFs. Cualquier otra extensión será ignorada por la aplicación y el proceso de impresión.



## TODO:

* Translations (get labels from Resource files instead of using text directly)
* Add "click filelist to open FileChooser" if the user doesn't want (or can't) drag and drop files.
* Responsive UI (not needed really)
* Controls for basic print settings (B/W or color, number of copies, orientation, etc.)
