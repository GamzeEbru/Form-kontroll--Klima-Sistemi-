
 int lm35 = A1; //analog pin tanımlandı.
 float deger;
 float cikti;
 float sicaklik;

 int fanSpeed;
 int minSicaklik =15;
 int maxSicaklik=40;
 const int fan_kontrol =3;
float sicaklik1;
 
void setup() {
  Serial.begin(9600);
   pinMode(8, OUTPUT); 
   pinMode(9, OUTPUT); 
   pinMode(10, OUTPUT); 
   pinMode(3, OUTPUT);
   digitalWrite(3, LOW);
}
void loop() {
 int deger = analogRead(lm35);

   float cikti = (deger/1024.0)*5000;
   float sicaklik = cikti/10.0;
   Serial.println(sicaklik);
   
    if(sicaklik>0 && sicaklik <18){
        digitalWrite(10,HIGH);  
        digitalWrite(9,LOW);
        digitalWrite(8,LOW);
        digitalWrite(3, LOW); 
        
         }
     if(sicaklik>18 && sicaklik <25){
        digitalWrite(9,HIGH);  
        digitalWrite(10,LOW);
        digitalWrite(8,LOW);
        digitalWrite(3, LOW);
        
         }
     if(sicaklik>25 ){
        digitalWrite(8,HIGH); 
        digitalWrite(9,LOW);
        digitalWrite(10,LOW); 
        digitalWrite(3, 255);;
         }
  
      delay(3000);
 
}
