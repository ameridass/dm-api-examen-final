----- Estudiantes

SELECT * FROM students st;

DELETE FROM students WHERE carrera_estudiante = null OR carrera_estudiante = '';

-- Crear una tabla temporal para generar datos aleatorios
CREATE TABLE #DatosEstudiantes (
    nombre_estudiante NVARCHAR(50),
    carrera_estudiante NVARCHAR(50),
    correo_estudiante NVARCHAR(50),
    telefono_estudiante NVARCHAR(20),
    genero_estudiante NVARCHAR(10),
    fecha_ingreso DATE,
    carne_estudiante NVARCHAR(20)
)

-- Insertar datos aleatorios en la tabla temporal
DECLARE @i INT = 1

WHILE @i <= 50 
BEGIN
    INSERT INTO students  (
        nombre_estudiante,
        carrera_estudiante,
        correo_estudiante,
        telefono_estudiante,
        genero_estudiante,
        fecha_ingreso,
        carne_estudiante
    )
    VALUES (
        'Estudiante' + CAST(@i AS NVARCHAR(10)),
        CASE ABS(CHECKSUM(NEWID())) % 4
            WHEN 0 THEN 'Carrera A'
            WHEN 1 THEN 'Carrera B'
            WHEN 2 THEN 'Carrera C'
            WHEN 3 THEN 'Carrera D'
        END,
        'estudiante' + CAST(@i AS NVARCHAR(10)) + '@correo.com',
        '555-123456' + RIGHT('000' + CAST(@i AS NVARCHAR(10)), 3),
        CASE ABS(CHECKSUM(NEWID())) % 2
            WHEN 0 THEN 'Masculino'
            WHEN 1 THEN 'Femenino'
        END,
        DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()),  -- Fecha de ingreso en los últimos 365 días
        'CARNE-' + RIGHT('0000' + CAST(@i AS NVARCHAR(10)), 4)
    )

    SET @i = @i + 1
END

-- Consultar los datos generados
SELECT * FROM #DatosEstudiantes

-- Eliminar la tabla temporal
DROP TABLE #DatosEstudiantes;

------ CURSOS
SELECT * FROM course c;

CREATE TABLE #DatosCursos (
    nombre_curso NVARCHAR(50),
    semestre_curso NVARCHAR(10),
    creditos_curso INT
)


DECLARE @i INT = 1

WHILE @i <= 50  
BEGIN
    INSERT INTO course (
        nombre_curso,
        semestre_curso,
        creditos_curso
    )
    VALUES (
        'Curso ' + CAST(@i AS NVARCHAR(10)),
        ABS(CHECKSUM(NEWID())) % 10 + 1, -- Semestre entre 1 y 10
        ABS(CHECKSUM(NEWID())) % 5 + 1  -- Créditos entre 1 y 5
    )

    SET @i = @i + 1
END

SELECT * FROM #DatosCursos

DROP TABLE #DatosCursos

----- ASIGNACIONES

select * FROM [assignment] a ;

CREATE TABLE #DatosAsignaciones (
    id_curso INT,
    id_estudiante INT,
    seccion_asignacion NVARCHAR(10),
    fecha_realizacion DATE,
    semestre_asignacion INT,
    ano_asignacion INT
);


DECLARE @i INT = 1

WHILE @i <= 50 
BEGIN
    INSERT INTO [assignment] (
        id_curso,
        id_estudiante,
        seccion_asignacion,
        fecha_realizacion,
        semestre_asignacion,
        año_asignacion
    )
    VALUES (
        ABS(CHECKSUM(NEWID())) % 10 + 1,  -- ID del curso entre 1 y 10
        ABS(CHECKSUM(NEWID())) % 100 + 1, -- ID del estudiante entre 1 y 100
        'Seccion ' + CAST((ABS(CHECKSUM(NEWID())) % 5) + 1 AS NVARCHAR(10)), -- Seccion entre 1 y 5
        DATEADD(DAY, -ABS(CHECKSUM(NEWID())) % 365, GETDATE()), -- Fecha de realización en los últimos 365 días
        ABS(CHECKSUM(NEWID())) % 10 + 1, -- Semestre entre 1 y 10
        YEAR(GETDATE()) - (ABS(CHECKSUM(NEWID())) % 10) -- Año de asignación entre el año actual y 10 años atrás
    )

    SET @i = @i + 1
END

SELECT * FROM #DatosAsignaciones

DROP TABLE #DatosAsignaciones

select * from course c WHERE id = 10;