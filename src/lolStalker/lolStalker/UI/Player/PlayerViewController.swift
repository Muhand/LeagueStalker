////
////  PlayerViewController.swift
////  lolStalker
////
////  Created by Muhand Jumah on 6/8/18.
////  Copyright © 2018 Muhand Jumah. All rights reserved.
////
//
//import Foundation
//import UIKit
//
//class PlayerViewController: UIViewController {
//    ////////////////////////////////////
//    //            Controls
//    ////////////////////////////////////
//    let parentScrollView: UIScrollView = {
//        let view = UIScrollView()
//        view.backgroundColor = .red
//        return view
//    }()
//
//    let playerView: PlayerView = {
//        let view = PlayerView()
//
////        var player: Player = Player()
////        player.summonerName = "WarDesigner"
////        player.championName = "Aatrox"
////        player.backgroundImage = #imageLiteral(resourceName: "tempChampion")
////        player.profileImage = #imageLiteral(resourceName: "tempProfile")
////        player.spell1 = #imageLiteral(resourceName: "tempSpell1")
////        player.spell2 = #imageLiteral(resourceName: "tempSpell2")
//
////        var team: Team
//
////        do {
////            team = try Team(players: player, player, player, player, player)
////            view.game = Game(team1: team, team2: team)
////        } catch {
////            print(error)
////        }
//
//
//        return view
//    }()
//
//    ////////// END OF CONTROLS /////////
//    override func viewDidLoad() {
//        super.viewDidLoad()
//        setupView()
//        setupSubViews()
//        setupConstraints()
//        setupMargins()
//    }
//
//    func setupView() {
//        view.backgroundColor = UIColor(hex: "#010A13")
////        view.backgroundColor = .green
//        hideKeyboardWhenTappedAround()
//    }
//
//    func setupSubViews() {
//        view.addSubview(playerView)
////        parentScrollView.addSubview(playerView)
//
//        playerView.delegate = self
//    }
//
//    func setupConstraints() {
//        parentScrollView.translatesAutoresizingMaskIntoConstraints = false
//        playerView.translatesAutoresizingMaskIntoConstraints = false
//
////        view.addConstraintsWithFormat(format: "V:|[v0]|", views: parentScrollView)
////        view.addConstraintsWithFormat(format: "H:|[v0]|", views: parentScrollView)
//
////        parentScrollView.addConstraintsWithFormat(format: "H:|-\(Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil))-[v0]-\(Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil))-|", views: playerView)
////        parentScrollView.addConstraintsWithFormat(format: "H:|[v0]|", views: playerView)
////        parentScrollView.addConstraintsWithFormat(format: "V:|[v0]|", views: playerView)
//
////        parentScrollView.addConstraintsWithFormat(format: "V:|-\(UIApplication.shared.statusBarFrame.height)-[v0]|", views: playerView)
//
//        playerView.centerXAnchor.constraint(equalTo: view.centerXAnchor).isActive = true
//        playerView.bottomAnchor.constraint(equalTo: view.bottomAnchor).isActive = true
//        playerView.heightAnchor.constraint(equalTo: view.heightAnchor, constant: -UIApplication.shared.statusBarFrame.height).isActive = true
//        playerView.widthAnchor.constraint(equalTo: view.widthAnchor, constant: -Helper.getWidthOf(xdWidth: 24, referenceWidth: nil, originalWidth: nil)).isActive = true
//
//    }
//
//    func setupMargins() {
//    }
//
//    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
//        super.viewWillTransition(to: size, with: coordinator)
//        view.setNeedsDisplay()
//    }
//
//}
//
//extension PlayerViewController: PlayerViewDelegate {
//    func cancelPressed(form: PlayerView) {
//        dismiss(animated: true, completion: nil)
//    }
//
//    func didSetPlayer(player: Player, form: PlayerView) {
//
//    }
//}

import Foundation
import UIKit

class PlayerViewController: UIViewController {
    ////////////////////////////////////
    //            Controls
    ////////////////////////////////////
//    let parentView: UIView = {
//        let view = UIView()
//        return view
//    }()
    
    let cancelBtn: UIButton = {
        let button = UIButton()
        button.setBackgroundColor(color: UIColor(hex: "#010A13")!, forState: .normal)
        button.setBackgroundColor(color: UIColor(hex: "#CE9340")!, forState: .highlighted)
        button.setTitleColor(UIColor(hex: "#CE9340"), for: .normal)
        button.setTitleColor(UIColor(hex: "#010A13"), for: .highlighted)
        button.setTitle("CANCEL", for: .normal)
        button.layer.borderWidth = Helper.getWidthOf(xdWidth: 1, referenceWidth: nil, originalWidth: nil)
        button.layer.borderColor = UIColor(hex: "#CE9340")?.cgColor
        button.titleLabel?.font = UIFont.systemFont(ofSize: Helper.getFontOf(xdFont: 12, referenceHeight: nil, referenceWidth: nil))
        button.addTarget(self, action: #selector(cancelPressed), for: .touchUpInside)
        return button
    }()
    
    let topContentView: UIView = {
        let view = UIView()
        view.backgroundColor = .green
        return view
    }()
    
//    let restOfContentView: UICollectionView = {
//        let view = UICollectionView()
//        view.backgroundColor = .purple
//        return view
//    }()
    
    ////////// END OF CONTROLS /////////
    
    override func viewDidLoad() {
        super.viewDidLoad()
        setupView()
        setupSubViews()
        setupConstraints()
    }
    
    func setupView() {
//        view.backgroundColor = UIColor(hex: "#010A13")
        view.backgroundColor = .red
        hideKeyboardWhenTappedAround()
//        restOfContentView.delegate = self
    }
    
    func setupSubViews() {
//        view.addSubview(parentView)
        view.addSubview(cancelBtn)
        view.addSubview(topContentView)
//        parentView.addSubview(restOfContentView)
    }
    
    func setupConstraints() {
        // Disable frames
//        parentView.translatesAutoresizingMaskIntoConstraints = false
        cancelBtn.translatesAutoresizingMaskIntoConstraints = false
        topContentView.translatesAutoresizingMaskIntoConstraints = false
//        restOfContentView.translatesAutoresizingMaskIntoConstraints = false
        
        // Setup constraints
//        parentView.topAnchor.constraint(equalTo: view.topAnchor, constant: UIApplication.shared
//            .statusBarFrame.height).isActive = true
//        parentView.bottomAnchor.constraint(equalTo: view.bottomAnchor).isActive = true
//        parentView.leftAnchor.constraint(equalTo: view.leftAnchor, constant: Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil)).isActive = true
//        parentView.rightAnchor.constraint(equalTo: view.rightAnchor, constant: -Helper.getWidthOf(xdWidth: 12, referenceWidth: nil, originalWidth: nil)).isActive = true
//
        // Cancel Button
        cancelBtn.widthAnchor.constraint(equalToConstant: Helper.getWidthOf(xdWidth: 76, referenceWidth: nil, originalWidth: nil)).isActive = true
        cancelBtn.heightAnchor.constraint(equalToConstant: Helper.getHeightOf(xdHeight: 21.36, referenceHeight: nil, originalHeight: nil)).isActive = true
        cancelBtn.topAnchor.constraint(equalTo: view.topAnchor).isActive = true
        cancelBtn.leftAnchor.constraint(equalTo: view.leftAnchor).isActive = true
        
        // Top content view
        topContentView.widthAnchor.constraint(equalTo: view.widthAnchor).isActive = true
        topContentView.heightAnchor.constraint(equalTo: view.heightAnchor, constant: -200).isActive = true
        topContentView.topAnchor.constraint(equalTo: view.topAnchor).isActive = true
        topContentView.leftAnchor.constraint(equalTo: view.leftAnchor).isActive = true
        
        // Rest of the content
//        restOfContentView.widthAnchor.constraint(equalTo: parentView.widthAnchor).isActive = true
//        restOfContentView.topAnchor.constraint(equalTo: topContentView.bottomAnchor).isActive = true
//        restOfContentView.heightAnchor.constraint(equalToConstant: 200).isActive = true
//        restOfContentView.centerXAnchor.constraint(equalTo: parentView.centerXAnchor).isActive = true
    }
    
    override func viewWillTransition(to size: CGSize, with coordinator: UIViewControllerTransitionCoordinator) {
        super.viewWillTransition(to: size, with: coordinator)
        view.setNeedsDisplay()
    }
    
    override func viewWillLayoutSubviews() {
        view.frame = CGRect(x: 0, y: 0, width: UIScreen.main.bounds.width - 24, height: 400)
    }
    
    ////////////////////////////////////
    //            Actions
    ////////////////////////////////////
    @IBAction func cancelPressed(sender: AnyObject) {
        dismiss(animated: true, completion: nil)
    }
}


extension PlayerViewController: UICollectionViewDelegate {
    
}
