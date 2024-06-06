CREATE TABLE Students (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125) NOT NULL,
    BirthDate DATE NOT NULL,
    Address VARCHAR(125) NOT NULL,
    Email VARCHAR(125) NOT NULL
);

-- DROP TABLE Students;

INSERT INTO Students (Names, BirthDate, Address, Email)
VALUES ("Juanky", "2005-02-03", "Calle 1 # 1-D 11", "juan.herrerachamat@inemjose.edu.co");

CREATE TABLE Teachers (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125) NOT NULL,
    Specialty VARCHAR(125) NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Email VARCHAR(125) NOT NULL,
    YearsExperience INT NOT NULL
);

-- DROP TABLE Teachers;

INSERT INTO Teachers (Names, Specialty, Phone, Email, YearsExperience)
VALUES ("Julio", "Matemáticas", "31234567", "julioprofe@gmail.com", 10)

CREATE TABLE Courses (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    Description TEXT NOT NULL,
    TeacherId INT NOT NULL,
    Schedule VARCHAR(125) NOT NULL,
    Duration INT NOT NULL,
    Capacity INT NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

DROP TABLE Courses;
TRUNCATE TABLE Courses;

INSERT INTO Courses (Name, Description, TeacherId, Schedule, Duration, Capacity)
VALUES ("Ecuaciones 1", "En este curso se desarrollarás las habiliadades necesarias para poder resolver ecuaciones", 1, "Lunes, Martes y Viernes: 2:00PM", 2, 30),
('Vocales 2', 'En este curso se desarrollará las habiliadades necesarias para aprender e identificar las vocales', 2, 'Jueves, Miercoles y Viernes: 5:00PM', 1, 45)

CREATE TABLE Enrollments (
    Id INT PRIMARY KEY AUTO_INCREMENT,
    Date DATE NOT NULL,
    StudentId INT(10) NOT NULL,
    CourseId INT(10) NOT NULL,
    Status ENUM("Pagada", "Pendiente de Pago", "Cancelada") NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

DROP TABLE Enrollments;

INSERT INTO Enrollments (Date, StudentId, CourseId, Status)
VALUES ("2024-01-12", 1, 1, "Pagada"),
('2024-02-22', '3', '2', 'Cancelada');