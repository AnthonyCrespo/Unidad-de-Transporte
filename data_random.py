import random, datetime, string
import psycopg2
from PIL import Image, ImageDraw, ImageFont

#Fecha aleatoria en un rango
def random_f():
    start_date = datetime.date(2019, 1, 1)
    end_date = datetime.date(2022, 4, 11)
    time_between_dates = end_date - start_date
    days_between_dates = time_between_dates.days
    random_number_of_days = random.randrange(days_between_dates)
    random_date = start_date + datetime.timedelta(days=random_number_of_days)
    return random_date

#String aleatorio
def random_s():
    length_of_string = random.choice([i for i in range(1,41)])
    return ''.join(random.SystemRandom().choice(string.ascii_letters + string.digits) for _ in range(length_of_string))

def respuestas(num_reporte, strSQL, p1, p2):
    for j in range(p1,p2+1):
        strSQL += f"({num_reporte},{j},'{random.choice(['y','n'])}', '{random.choice([random_s(),''])}'),"
    return strSQL



def descripcion(num_reporte, strSQL):
    n = random.randint(1,10)
    l = [1,2,3,4,5,6,7,8,9,10]
    s = random.sample(l,n)
    s.sort()
    comando = ""
    for j in range(1,len(s)+1):
        comando += strSQL + f"({num_reporte},{s[j-1]},'{random_s()}');"
    return comando


provincias = ['Azuay','Bolivar','Cañar','Carchi','Chimborazo','Cotopaxi','El Oro','Esmeraldas','Galápagos',
              'Guayanas','Imbabura','Loja','Los Ríos','Manabí','Morona Santiago','Napo','Sucumbíos','Pastaza',
              'Pinchincha','Santa Elena','Santo Domingo','Francisco De Orellana','Tungurahua','Zamora Chinchipe']
nombres = ['Juan', 'Luis', 'Alberto', 'Anthony', 'Santiago', 'Luis', 'Francisco', 'Alfredo']
apellidos = ['Crespo', 'Rodriguez', 'Suarez', 'Mora', 'Hernandez', 'Gonzales', 'Martinez']
base_operativa = 'H.G.S.V.P.'
alfa = [i for i in range(20)]
hora = ['00','01','02','03','04','05','06','07','08',
        '09'] + [str(i) for i in range(10,24)]
minutos = ['00','01','02','03','04','05','06','07','08','09'] + [str(i) for i in range(10,60)]
coordinacion_zonal = [i for i in range(1,10)]
num_reporte = 101

s1 = "insert into datos_generales values "
s2 = "insert into limpieza values "
s3 = "insert into cabina_interior values "
s4 = "insert into documentos values "
s5 = "insert into cabina_exterior values "
s7 = ""
s8 = "insert into otros_datos values " 

n = 29900
for i in range(n):
    #Datos generales
    s1 += f"({num_reporte}, {random.choice(coordinacion_zonal)},'{random.choice(nombres)} {random.choice(apellidos)}', '{random.choice(nombres)} {random.choice(apellidos)}',"
    s1 += f"'{random.choice(provincias)}', '{base_operativa}', '{random.choice(alfa)}', '{base_operativa}', '{random.choice(hora)}:{random.choice(minutos)}', '{random_f()}')"
    #limpieza
    s2 = respuestas(num_reporte, s2, 1, 2)
    #Cabina Interior
    s3 = respuestas(num_reporte, s3, 3, 21)
    #Documentos
    s4 = respuestas(num_reporte, s4, 22, 25)
    #Cabina Exterior
    s5 = respuestas(num_reporte, s5, 26, 47)
    #danos
    s7 += descripcion(num_reporte, "insert into danos values ")

    temperatura = ["Frío","Medio","Caliente"]
    #otros datos
    s8 += f"({num_reporte}, {random.randint(25,100)}, '{random.choice(temperatura)}', {random.randint(10000, 40000)}, '{random_s()}'),"
    if i < n-1:
        s1 +=", "
    else:
        s1 += ";"
        s2 = s2[:-1] + ";"
        s3 = s3[:-1] + ";"
        s4 = s4[:-1] + ";"
        s5 = s5[:-1] + ";"
        s8 = s8[:-1] + ";"
    print(num_reporte)
    num_reporte += 1

comandos = [s1,s2,s3,s4,s5,s7,s8]

#Coneccion a la DB

cn = psycopg2.connect(
    user = "postgres",
    password="1234",
    host = "127.0.0.1",
    port = "5432",
    database = "test2"
)

cursor = cn.cursor()
for comando in comandos:
    cursor.execute(comando)
    cn.commit()