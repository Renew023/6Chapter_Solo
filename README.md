# 🎮 6Chapter_Solo – 3D 방치형 RPG 구현
---

## ✅ 과제 기능

### 🔹 필수 구현

- 기본 UI 시스템  
- 플레이어 AI 시스템  
- 아이템 및 업그레이드 시스템  
- 게임 내 통화(Gold) 시스템  
- 장비 인벤토리 UI  
- 스테이지 진행 시스템  
- ScriptableObject 기반 데이터 관리  

### 🔸 선택 구현

- 사운드 이펙트 시스템  
- 저장 및 로드 시스템
- 다이나믹 카메라 효과 (06-11)
- 랜덤 맵 생성 기능 (06-11)

---

## 🧩 기능 상세 설명

### 📌 기본 UI 구현
- 능력치 및 상호작용 버튼 UI 제공  
- 제한된 리소스 내에서 Outline, 색상, 텍스트로 가독성 확보  
![UI Image](https://github.com/user-attachments/assets/445edadf-8029-45e7-a444-3dd90a04bfcc)

---

### 🤖 플레이어 AI 시스템
- 몬스터와의 거리 계산 → 최단 거리 적 추적  
- 일정 거리 이내 접근 시 공격 상태로 전환  
![AI Image](https://github.com/user-attachments/assets/47097b6d-a393-484e-a87a-619142b9c29e)

---

### 🛡️ 아이템 및 업그레이드 시스템
- 공격력, 체력, 속도 등 능력치를 골드로 구매 가능  
- 능력치가 실시간으로 Player에 반영  
![Upgrade System](https://github.com/user-attachments/assets/f8d51cad-55ac-4225-8daf-798d19954846)

---

### 💰 게임 내 통화 시스템
- 몬스터 처치 시 골드 획득  
- 업그레이드 및 아이템 구매에 사용  

---

### 🎒 아이템 및 장비창 UI
- 장비 아이템 장착 / 해제 기능  
- 드랍 아이템 스택 구현 → 방치형 설계 반영  
![Inventory](https://github.com/user-attachments/assets/7aa42c0d-a986-4690-94d5-52ebd7fdf5d4)

---

### 🗺️ 스테이지 시스템
- `ScriptableObject`를 통한 각 Stage 구성  
- `MonsterSpawner`에서 `List<Stage>`를 참조하여 몬스터 생성  
![Stage](https://github.com/user-attachments/assets/364ac56e-cb91-47fe-8564-11277a2b4992)

---

### 🧱 ScriptableObject 기반 데이터 관리
- `ItemData` → `InventoryItem`, `EquipItem`, `ResourceItem` 등으로 세분화  
- `Player`, `Enemy`, `Item`, `Stage` 등 객체별 데이터 지정  
![SO Image](https://github.com/user-attachments/assets/0cccbfba-3dae-4b05-90ad-17a810b0009a)

---

### 🔊 사운드 이펙트
- 공격, 이동, 사망, 버튼 클릭, 레벨업 등 상황별 효과음 구현  
- `AudioManager`를 싱글턴화하여 모든 시스템과 연결

---

### 💾 저장 및 로드 시스템
- 제네릭 메서드 기반 저장 시스템  
- `Setting`, `Inventory`, `Player`, `Stage`, `ShopData` 등 필요한 값만 구조체로 저장
- 현재 구현된 것은 플레이어의 저장 기능인데 일부 문제 확인 필요.
![Save/Load](https://github.com/user-attachments/assets/abc22158-3775-4bbf-8a1a-210d8ec59713)

---

### 🔄 다이나믹 카메라 효과
- 플레이어의 **이동**, **공격**, **사망** 상태에 따라 카메라가 반응하도록 설정  
- 카메라 효과는 간단한 **Zoom In / Zoom Out** 형태로 구현하여 동적인 연출 제공  
![Movie_003](https://github.com/user-attachments/assets/e5f93eda-b0c1-4771-a1bb-4f6217435b33)

---

### 🌍 랜덤 맵 생성 기능
- `Random.InitState`를 사용해 시드 기반 맵 생성  
- 플레이어 주변 **4방면을 탐색**해 오브젝트 유무 판단 후 생성  
- **모든 방향이 차단**된 경우 생성 범위(탐색 범위)를 증가시켜 확장  
- 먼저 **Grid 데이터를 구축**한 후, Prefab을 배치하는 방식  
- 현재 몬스터 및 플레이어는 지형 인식 없이 움직임  
  - 추후 `NavMesh` 도입 예정  
![image](https://github.com/user-attachments/assets/c8e0c449-d8ae-4726-88c2-3751c3b8d61b)

---

## 🛠️ 기술 스택 및 설계

| 기술 요소 | 설명 |
|----------|------|
| `StateMachine` 패턴 | 플레이어 및 몬스터 상태 제어 |
| 확장 메서드 | Button에 사운드 효과 할당 등 |
| 키 상수 관리 | 애니메이션 및 저장 키의 string/Hash 관리 |
| `ScriptableObject` 구조 설계 | 역할 분리 및 유지보수 고려 |
| Update 최적화 | 각 객체 Update → `StateMachineManager`에서 통합 관리 |

---

## 🐞 트러블슈팅

## 🐞 트러블슈팅

### 🎯 애니메이션 타격 오류 (2025.06.10)
- **문제:** 공격 애니메이션이 `normalizeTime = 1.0` 전에 중단  
- **원인:** `HasExitTime` 설정만으로는 부족, `Transition Duration` 값 영향  
- **해결:** 해당 애니메이션의 `Transition Duration`을 `0`으로 수정하여 정확한 종료 처리

### 🧩 Dictionary Null 오류 (2025.06.11)
- **문제:** Dictionary 사용 시 NullReferenceException 발생  
- **원인:** `new` 키워드 없이 초기화되지 않은 상태에서 접근  
- **해결:** Dictionary 선언 시 `new`로 명확히 초기화  

### 🎥 카메라 원하는 위치로 이동하지 않는 문제 (2025.06.10)
- **문제:** 카메라가 지정한 위치로 정확히 이동하지 않음  
- **원인:** 이동 좌표값의 오차로 인해 이상 동작 발생  
- **해결:** 좌표값 재조정하여 정상 이동하도록 수정  

### 🎬 Cinemachine 전환 문제 (2025.06.10)
- **문제:** 카메라 전환 시 멈춤 현상 발생  
- **원인:** `Time.timeScale = 0` 상태에서는 Blend 효과 작동하지 않음  
- **해결:** `LateUpdate`를 사용하고, `Ignore TimeScale` 설정 체크하여 문제 해결  

---
